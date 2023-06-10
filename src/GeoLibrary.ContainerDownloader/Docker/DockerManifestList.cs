namespace GeoLibrary.ContainerDownloader.Docker;

internal class DockerManifestList : ManifestListBase
{
     public const string MediaType = "application/vnd.docker.distribution.manifest.list.v2+json";

    public DockerManifestList(string content)
        : base(content)
    {
    }

    protected override string GetMediaType()
    {
        return MediaType;
    }
}
