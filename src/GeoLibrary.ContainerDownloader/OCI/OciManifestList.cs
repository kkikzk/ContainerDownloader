using GeoLibrary.ContainerDownloader.Docker;
using System.Threading.Tasks;
using System.Threading;

namespace GeoLibrary.ContainerDownloader.OCI;

internal class OciManifestList : ManifestListBase
{
    public const string MediaType = "application/vnd.oci.image.index.v1+json";

    public OciManifestList(string content)
        : base(content)
    {
    }

    public override Task<IContainerManifest> GetManifestAsync(IHttpClient client, DockerAuthentication auth, ContainerPlatform platform, CancellationToken token)
    {
        client.AddDefaultRequestHeaders("Accept", "application/vnd.oci.image.manifest.v1+json");
        return base.GetManifestAsync(client, auth, platform, token);
    }

    protected override string GetMediaType()
    {
        return MediaType;
    }
}
