using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLibrary.ContainerDownloader;

public interface IContainerManifest
{
    public interface IConfig
    {
        string MediaType { get; }
        string Digest { get; }
        int Size { get; }
    }

    public interface ILayer
    {
        string MediaType { get; }
        string Digest { get; }
        int Size { get; }
    }

    int SchemaVersion { get; }
    string MediaType { get; }
    IConfig Config { get; }
    ILayer[] Layers { get; }

    Task PullAsync(HttpClient client, DirectoryInfo dir, CancellationToken token);
    Task PullAsync(IHttpClient client, DirectoryInfo dir, CancellationToken token);
}
