using GeoLibrary.ContainerDownloader.OCI;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLibrary.ContainerDownloader.Docker;

public class DockerHub
{
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

    public static Task<ContainerManifest> GetConfigAsync(HttpClient client, string companyName, string imageName, ContainerPlatform platform, string tag, CancellationToken token)
    {
        return GetConfigAsync(new HttpClientWrapper(client), companyName, imageName, platform, tag, token);
    }

    public static async Task<ContainerManifest> GetConfigAsync(IHttpClient client, string companyName, string imageName, ContainerPlatform platform, string tag, CancellationToken token)
    {
        client.AddDefaultRequestHeaders("Accept", "application/vnd.docker.distribution.manifest.v2+json");
        client.AddDefaultRequestHeaders("Accept", DockerManifestList.MediaType);
        client.AddDefaultRequestHeaders("Accept", OciManifestList.MediaType);

        var url = $"https://registry-1.docker.io/v2/{companyName}/{imageName}/manifests/{tag}";
        var content = await client.GetContentAsStringAsync(url, token).ConfigureAwait(false);

        var deserialized = JsonSerializer.Deserialize<Content>(content);
        return (deserialized.SchemaVersion, deserialized.MediaType) switch
        {
            (2, DockerManifestList.MediaType) => await new DockerManifestList(content).GetManifestAsync(client, companyName, imageName, platform, token).ConfigureAwait(false),
            (2, OciManifestList.MediaType) => await new OciManifestList(content).GetManifestAsync(client, companyName, imageName, platform, token).ConfigureAwait(false),
            _ => throw new ContainerDownloaderException($"Schema not supported. [version={deserialized.SchemaVersion}, mediaType={deserialized.MediaType}]"),
        };
    }

    //public Task PullAsync(HttpClient client, DirectoryInfo dir, string companyName, string imageName, ContainerManifest manifest, CancellationToken token)
    //{
    //    return PullAsync(new HttpClientWrapper(client), dir, companyName, imageName, manifest, token);
    //}

    //public async Task PullAsync(IHttpClient client, DirectoryInfo dir, string companyName, string imageName, ContainerManifest manifest, CancellationToken token)
    //{
    //    for (var i = 0; i < manifest.Layers.Length; ++i)
    //    {
    //        var url = $"https://registry-1.docker.io/v2/{companyName}/{imageName}/blobs/{manifest.Layers[i].Digest}";
    //        var file = new FileInfo(Path.Combine(dir.FullName, $"layer{i}.tar.gz"));
    //        var stream = await client.GetStreamAsync(url, token).ConfigureAwait(false);
    //        using (var destinationStream = File.Create(file.FullName))
    //        {
    //            // 元のストリームを出力先のストリームにコピー
    //            stream.CopyTo(destinationStream);
    //        }
    //    }
    //}
}