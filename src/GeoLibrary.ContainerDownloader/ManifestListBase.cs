using GeoLibrary.ContainerDownloader.Docker;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;

namespace GeoLibrary.ContainerDownloader;

public abstract class ManifestListBase
{
    private readonly record struct Platform
    {
        [JsonPropertyName("architecture")]
        public string Architecture { get; }
        [JsonPropertyName("os")]
        public string Os { get; }
        [JsonPropertyName("variant")]
        public string Variant { get; }

        [JsonConstructor]
        public Platform(string architecture, string os, string variant) =>
           (Architecture, Os, Variant) = (architecture, os, variant);
    }

    private readonly record struct Manifest
    {
        [JsonPropertyName("digest")]
        public string Digest { get; }
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }
        [JsonPropertyName("platform")]
        public Platform Platform { get; }
        [JsonPropertyName("size")]
        public int Size { get; }

        [JsonConstructor]
        public Manifest(string digest, string mediaType, Platform platform, int size) =>
            (Digest, MediaType, Platform, Size) = (digest, mediaType, platform, size);
    }

    private readonly record struct Content
    {
        [JsonPropertyName("schemaVersion")]
        public int SchemaVersion { get; }
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }
        [JsonPropertyName("manifests")]
        public Manifest[] Manifests { get; }

        [JsonConstructor]
        public Content(int schemaVersion, string mediaType, Manifest[] manifests) =>
            (SchemaVersion, MediaType, Manifests) = (schemaVersion, mediaType, manifests);
    }

    private readonly Content _content;
    private readonly string _json;

    public ManifestListBase(string content)
    {
        _content = JsonSerializer.Deserialize<Content>(content);
        _json = content;

        if (_content.SchemaVersion != 2 || _content.MediaType != GetMediaType())
        {
            throw new ContainerDownloaderException($"Schema not supported. [version={_content.SchemaVersion}, mediaType={_content.MediaType}]");
        }
    }

    protected abstract string GetMediaType();

    public virtual Task<IContainerManifest> GetManifestAsync(HttpClient client, string campanyName, string imageName, ContainerPlatform platform, CancellationToken token)
    {
        return GetManifestAsync(new HttpClientWrapper(client), campanyName, imageName, platform, token);
    }

    public virtual async Task<IContainerManifest> GetManifestAsync(IHttpClient client, string campanyName, string imageName, ContainerPlatform platform, CancellationToken token)
    {
        var manifest = GetManifest(platform);

        var url = $"https://registry-1.docker.io/v2/{campanyName}/{imageName}/manifests/{manifest.Digest}";
        var content = await client.GetContentAsStringAsync(url, token).ConfigureAwait(false);

        using var jsonDoc = JsonDocument.Parse(content);
        var root = jsonDoc.RootElement;

        var layers = new List<DockerManifest.Layer>();
        foreach (var it in root.GetProperty("layers").EnumerateArray())
        {
            layers.Add(ToLayer(it));
        }
        var config = ToConfig(root.GetProperty("config"));
        var schemaVersion = root.GetProperty("schemaVersion").GetInt32();
        var mediaType = root.GetProperty("mediaType").GetString() ?? throw new JsonElementMissingException("mediaType");

        return new DockerManifest(campanyName, imageName, schemaVersion, mediaType, config, layers.ToArray());
    }

    private static DockerManifest.Layer ToLayer(JsonElement element)
    {
        var mediaType = element.GetProperty("mediaType").GetString() ?? throw new JsonElementMissingException("mediaType");
        var digest = element.GetProperty("digest").GetString() ?? throw new JsonElementMissingException("digest");
        var size = element.GetProperty("size").GetInt32();
        return new DockerManifest.Layer(mediaType, digest, size);
    }

    private static DockerManifest.ConfigData ToConfig(JsonElement element)
    {
        var configMediaType = element.GetProperty("mediaType").GetString() ?? throw new JsonElementMissingException("mediaType");
        var configDigest = element.GetProperty("digest").GetString() ?? throw new JsonElementMissingException("digest");
        var configSize = element.GetProperty("size").GetInt32();
        return new DockerManifest.ConfigData(configMediaType, configDigest, configSize);
    }

    private Manifest GetManifest(ContainerPlatform platform)
    {
        foreach (var it in _content.Manifests)
        {
            if (it.Platform.Architecture == platform.Architecture && it.Platform.Os == platform.Os)
            {
                if (string.IsNullOrEmpty(it.Platform.Variant) && string.IsNullOrEmpty(platform.Variant))
                {
                    return it;
                }
                else if (!string.IsNullOrEmpty(it.Platform.Variant) || string.IsNullOrEmpty(platform.Variant))
                {
                    continue;
                }
                else if (string.IsNullOrEmpty(it.Platform.Variant) || !string.IsNullOrEmpty(platform.Variant))
                {
                    continue;
                }
                else if (it.Platform.Architecture == platform.Architecture)
                {
                    return it;
                }
            }
        }

        throw new ContainerDownloaderException($"Platform not found.[Arch={platform.Architecture}, OS={platform.Os}{(string.IsNullOrEmpty(platform.Variant) ? string.Empty : ", " + platform.Variant)}]");
    }

    public override string ToString()
    {
        return _json;
    }
}
