using System.Diagnostics;
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
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }

    [DebuggerStepThrough]
    public void AddDefaultRequestHeaders(string name, string value)
    {
        _httpClient.DefaultRequestHeaders.Add(name, value);
    }
}
