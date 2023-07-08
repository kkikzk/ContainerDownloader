using GeoLibrary.ContainerDownloader.OCI;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLibrary.ContainerDownloader.Docker;

public class DockerHub
{
    private readonly string _companyName;
    private readonly string _imageName;

    private readonly record struct Content
    {
        [JsonPropertyName("schemaVersion")]
        public int SchemaVersion { get; }
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }

        [JsonConstructor]
        public Content(int schemaVersion, string mediaType) =>
            (SchemaVersion, MediaType) = (schemaVersion, mediaType);
    }

    public DockerHub(string companyName, string imageName)
    {
        _companyName = companyName;
        _imageName = imageName;
    }

    public Task<ContainerManifest> GetManifestAsync(HttpClient client, ContainerPlatform platform, string tag, CancellationToken token)
    {
        return GetManifestAsync(new HttpClientWrapper(client), platform, tag, token);
    }

    public async Task<ContainerManifest> GetManifestAsync(IHttpClient client, ContainerPlatform platform, string tag, CancellationToken token)
    {
        client.AddDefaultRequestHeaders("Accept", "application/vnd.docker.distribution.manifest.v2+json");
        client.AddDefaultRequestHeaders("Accept", DockerManifestList.MediaType);
        client.AddDefaultRequestHeaders("Accept", OciManifestList.MediaType);

        var url = $"https://registry-1.docker.io/v2/{_companyName}/{_imageName}/manifests/{tag}";
        var content = await client.GetContentAsStringAsync(url, token).ConfigureAwait(false);

        var deserialized = JsonSerializer.Deserialize<Content>(content);
        return (deserialized.SchemaVersion, deserialized.MediaType) switch
        {
            (2, DockerManifestList.MediaType) => await new DockerManifestList(content).GetManifestAsync(client, _companyName, _imageName, platform, token).ConfigureAwait(false),
            (2, OciManifestList.MediaType) => await new OciManifestList(content).GetManifestAsync(client, _companyName, _imageName, platform, token).ConfigureAwait(false),
            _ => throw new ContainerDownloaderException($"Schema not supported. [version={deserialized.SchemaVersion}, mediaType={deserialized.MediaType}]"),
        };
    }

    public Task PullContainerAsync(HttpClient client, DirectoryInfo dir, ContainerManifest manifest, CancellationToken token)
    {
        return PullContainerAsync(new HttpClientWrapper(client), dir, manifest, token);
    }

    public async Task PullContainerAsync(IHttpClient client, DirectoryInfo dir, ContainerManifest manifest, CancellationToken token)
    {
        if (!dir.Exists)
        {
            throw new ArgumentException($"Directory does not exists. [path={dir.FullName}]");
        }

        // manifest
        var manifestFile = new FileInfo(Path.Combine(dir.FullName, "manifest.json"));
        await File.WriteAllTextAsync(manifestFile.FullName, manifest.Json, Encoding.UTF8, token).ConfigureAwait(false);

        // config
        var configUrl = $"https://registry-1.docker.io/v2/{_companyName}/{_imageName}/blobs/{manifest.Content.Config.Digest}";
        var configFile = new FileInfo(Path.Combine(dir.FullName, "config.json"));
        var configStream = await client.GetStreamAsync(configUrl, token).ConfigureAwait(false);
        using (var destinationStream = File.Create(configFile.FullName))
        {
            configStream.CopyTo(destinationStream);
        }

        // container
        for (var i = 0; i < manifest.Content.Layers.Length; ++i)
        {
            var url = $"https://registry-1.docker.io/v2/{_companyName}/{_imageName}/blobs/{manifest.Content.Layers[i].Digest}";
            var file = new FileInfo(Path.Combine(dir.FullName, $"layer{i}.tar.gz"));
            var stream = await client.GetStreamAsync(url, token).ConfigureAwait(false);
            using (var destinationStream = File.Create(file.FullName))
            {
                // 元のストリームを出力先のストリームにコピー
                stream.CopyTo(destinationStream);
            }
        }
    }
}