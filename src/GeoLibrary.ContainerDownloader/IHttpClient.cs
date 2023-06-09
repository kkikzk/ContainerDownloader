﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLibrary.ContainerDownloader;

public interface IHttpClient
{
    Task<string> GetContentAsStringAsync(string requestUri, CancellationToken cancellationToken);

    Task<Stream> GetStreamAsync(string requestUri, CancellationToken cancellationToken);

    void AddDefaultRequestHeaders(string name, string value);
}
