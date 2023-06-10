using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLibrary.ContainerDownloader.Docker;

public class DockerManifest : IContainerManifest
{
    private readonly string _companyName;
    private readonly string _imageName;

    public class ConfigData : IContainerManifest.IConfig
    {
        [JsonPropertyName("mediaType")]
        public string MediaType { set; get; }
        [JsonPropertyName("digest")]
        public string Digest { set; get; }
        [JsonPropertyName("size")]
        public int Size { set; get; }

        [JsonConstructor]
        public ConfigData(string mediaType, string digest, int size) =>
            (MediaType, Digest, Size) = (mediaType, digest, size);
    }

    public class Layer : IContainerManifest.ILayer
    {
        [JsonPropertyName("mediaType")]
        public string MediaType { set; get; }
        [JsonPropertyName("digest")]
        public string Digest { set; get; }
        [JsonPropertyName("size")]
        public int Size { set; get; }

        [JsonConstructor]
        public Layer(string mediaType, string digest, int size) =>
            (MediaType, Digest, Size) = (mediaType, digest, size);
    }

    [JsonPropertyName("schemaVersion")]
    public int SchemaVersion { set;  get; }
    [JsonPropertyName("mediaType")]
    public string MediaType { set;  get; }
    [JsonPropertyName("config")]
    public IContainerManifest.IConfig Config { set; get; }
    [JsonPropertyName("layers")]
    public IContainerManifest.ILayer[] Layers { set;  get; }

    [JsonConstructor]
    public DockerManifest(string companyName, string imageName, int schemaVersion, string mediaType, ConfigData config, Layer[] layers)
    {
        (SchemaVersion, MediaType, Config, Layers) = (schemaVersion, mediaType, config, layers);
        _companyName = companyName;
        _imageName = imageName;
    }

    public Task PullAsync(HttpClient client, DirectoryInfo dir, CancellationToken token)
    {
        return PullAsync(new HttpClientWrapper(client), dir, token);
    }

    public async Task PullAsync(IHttpClient client, DirectoryInfo dir, CancellationToken token)
    {
        for (var i = 0; i < Layers.Length; ++i)
        {
            var url = $"https://registry-1.docker.io/v2/{_companyName}/{_imageName}/blobs/{Layers[i].Digest}";
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
