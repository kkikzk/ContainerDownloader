using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLibrary.ContainerDownloader;

public class HttpClientWrapper : IHttpClient
{
    private readonly HttpClient _httpClient;

    [DebuggerStepThrough]
    public HttpClientWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [DebuggerStepThrough]
    public async Task<string> GetContentAsStringAsync(string requestUri, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
#if NETSTANDARD2_1
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#else
            return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#endif
        }
        else
        {
            var content = string.Empty;
            try
            {
#if NETSTANDARD2_1
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#else
                content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#endif
            }
            catch
            {
                // do nothing.
            }
            throw new ContainerDownloaderException($"Failed to get a content.[Status code={response.StatusCode}{(string.IsNullOrEmpty(content) ? string.Empty : ", Content = " + content)}]");
        }
    }

    [DebuggerStepThrough]
    public void AddDefaultRequestHeaders(string name, string value)
    {
        _httpClient.DefaultRequestHeaders.Add(name, value);
    }

    [DebuggerStepThrough]
    public Task<Stream> GetStreamAsync(string requestUri, CancellationToken cancellationToken)
    {
#if NETSTANDARD2_1
        return _httpClient.GetStreamAsync(requestUri);
#else
        return _httpClient.GetStreamAsync(requestUri, cancellationToken);
#endif
    }
}
