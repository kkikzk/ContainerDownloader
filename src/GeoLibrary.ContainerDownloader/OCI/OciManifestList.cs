﻿using GeoLibrary.ContainerDownloader.Docker;
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

    public override Task<IContainerManifest> GetManifestAsync(IHttpClient client, string companyName, string imageName, ContainerPlatform platform, CancellationToken token)
    {
        client.AddDefaultRequestHeaders("Accept", "application/vnd.oci.image.manifest.v1+json");
        return base.GetManifestAsync(client, companyName, imageName, platform, token);
    }

    protected override string GetMediaType()
    {
        return MediaType;
    }
}
