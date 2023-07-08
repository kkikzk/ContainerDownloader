using System.IO;
using System.Net.Http;
using System.Text;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Threading;

namespace GeoLibrary.ContainerDownloader;

public class ContainerManifest
{
    private readonly string _companyName;
    private readonly string _imageName;

    public readonly record struct ConfigData
    {
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }
        [JsonPropertyName("digest")]
        public string Digest { get; }
        [JsonPropertyName("size")]
        public int Size { get; }

        [JsonConstructor]
        public ConfigData(string mediaType, string digest, int size) =>
            (MediaType, Digest, Size) = (mediaType, digest, size);
    }

    public readonly record struct Layer
    {
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }
        [JsonPropertyName("digest")]
        public string Digest { get; }
        [JsonPropertyName("size")]
        public int Size { get; }

        [JsonConstructor]
        public Layer(string mediaType, string digest, int size) =>
            (MediaType, Digest, Size) = (mediaType, digest, size);
    }

    public readonly record struct ContentData
    {
        [JsonPropertyName("schemaVersion")]
        public int SchemaVersion { get; }
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }
        [JsonPropertyName("config")]
        public ConfigData Config { get; }
        [JsonPropertyName("layers")]
        public Layer[] Layers { get; }

        [JsonConstructor]
        public ContentData(int schemaVersion, string mediaType, ConfigData config, Layer[] layers) =>
            (SchemaVersion, MediaType, Config, Layers) = (schemaVersion, mediaType, config, layers);
    }

    public ContentData Content { get; }
    public string Json { get; }

    public ContainerManifest(string content, string companyName, string imageName)
    {
        Content = JsonSerializer.Deserialize<ContentData>(content);
        Json = content;
        _companyName = companyName;
        _imageName = imageName;
    }

    public Task PullContainerAsync(HttpClient client, DirectoryInfo dir, CancellationToken token)
    {
        return PullContainerAsync(new HttpClientWrapper(client), dir, token);
    }

    public async Task PullContainerAsync(IHttpClient client, DirectoryInfo dir, CancellationToken token)
    {
        if (!dir.Exists)
        {
            throw new ArgumentException($"Directory does not exists. [path={dir.FullName}]");
        }

        // manifest
        var manifestFile = new FileInfo(Path.Combine(dir.FullName, "manifest.json"));
        await File.WriteAllTextAsync(manifestFile.FullName, Json, Encoding.UTF8, token).ConfigureAwait(false);

        // config
        var configUrl = $"https://registry-1.docker.io/v2/{_companyName}/{_imageName}/blobs/{Content.Config.Digest}";
        var configFile = new FileInfo(Path.Combine(dir.FullName, "config.json"));
        var configStream = await client.GetStreamAsync(configUrl, token).ConfigureAwait(false);
        using (var destinationStream = File.Create(configFile.FullName))
        {
            configStream.CopyTo(destinationStream);
        }

        // container
        for (var i = 0; i < Content.Layers.Length; ++i)
        {
            var url = $"https://registry-1.docker.io/v2/{_companyName}/{_imageName}/blobs/{Content.Layers[i].Digest}";
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
