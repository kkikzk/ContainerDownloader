using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

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

    public virtual Task<ContainerManifest> GetManifestAsync(HttpClient client, string campanyName, string imageName, ContainerPlatform platform, CancellationToken token)
    {
        return GetManifestAsync(new HttpClientWrapper(client), campanyName, imageName, platform, token);
    }

    public virtual async Task<ContainerManifest> GetManifestAsync(IHttpClient client, string campanyName, string imageName, ContainerPlatform platform, CancellationToken token)
    {
        try
        {
            var digest = GetDigest(platform);
            var url = $"https://registry-1.docker.io/v2/{campanyName}/{imageName}/manifests/{digest}";
            var content = await client.GetContentAsStringAsync(url, token).ConfigureAwait(false);

            return new ContainerManifest(content);
        }
        catch (Exception ex)
        {
            throw new ContainerDownloaderException("Failed to get a manifest", ex);
        }
    }

    private string GetDigest(ContainerPlatform platform)
    {
        foreach (var it in _content.Manifests)
        {
            if (it.Platform.Architecture == platform.Architecture && it.Platform.Os == platform.Os)
            {
                if (string.IsNullOrEmpty(it.Platform.Variant) && string.IsNullOrEmpty(platform.Variant))
                {
                    return it.Digest;
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
                    return it.Digest;
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
