using System.Diagnostics;

namespace GeoLibrary.ContainerDownloader.Test.Mock;

internal class HttpClientMock : IHttpClient
{
    private readonly string[] _contents;
    private readonly Action<string, string> _action;
    private int _index;

    [DebuggerStepThrough]
    public HttpClientMock(IEnumerable<string> contents)
        : this(contents, (_1, _2) => { })
    {
    }

    [DebuggerStepThrough]
    public HttpClientMock(IEnumerable<string> contents, Action<string, string> action)
    {
        _contents = contents.ToArray();
        _action = action;
    }

    [DebuggerStepThrough]
    public Task<string> GetContentAsStringAsync(string requestUri, CancellationToken cancellationToken)
    {
        return Task.FromResult(_contents[_index++]);
    }

    [DebuggerStepThrough]
    public void AddDefaultRequestHeaders(string name, string value)
    {
        _action(name, value);
    }
}
