using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLibrary.ContainerDownloader.Docker;

public class DockerAuthentication
{
    private record struct Content
    {
        [JsonPropertyName("token")]
        public string Token { get; }
        [JsonPropertyName("access_token")]
        public string AccessToken { get; }

        [JsonConstructor]
        public Content(string token, string accessToken) =>
            (Token, AccessToken) = (token, accessToken);
    }

    private string _json = string.Empty;

    public string CompanyName { get; }
    public string ImageName { get; }
    public DockerRegistryAction Action { get; }
    public string Token { private set; get; } = string.Empty;
    public string AccessToken { private set; get; } = string.Empty;

    [DebuggerStepThrough]
    public DockerAuthentication(string companyName, string imageName, DockerRegistryAction action)
    {
        CompanyName = companyName;
        ImageName = imageName;
        Action = action;
    }

    public Task ExecuteAsync(HttpClient client, CancellationToken token)
    {
        return ExecuteAsync(new HttpClientWrapper(client), token);
    }

    internal async Task ExecuteAsync(IHttpClient client, CancellationToken token)
    {
        try
        {
            var scope = $"repository:{CompanyName}/{ImageName}:{GetAction()}";
            _json = await GetTokenAsync(client, scope, token).ConfigureAwait(false);
            var deserialized = JsonSerializer.Deserialize<Content>(_json);

            Token = deserialized.Token ?? throw new JsonElementMissingException("token");
            AccessToken = deserialized.AccessToken ?? throw new JsonElementMissingException("access_token");

            client.AddDefaultRequestHeaders("Authorization", $"Bearer {AccessToken}");
        }
        catch (Exception ex)
        {
            throw new ContainerDownloaderException("Failed to deserialize a content.", ex);
        }
    }

    private string GetAction()
    {
        return Action switch
        {
            DockerRegistryAction.Pull => "pull",
            DockerRegistryAction.Push => "push",
            DockerRegistryAction.All => "pull,push",
            _ => throw new ApplicationException($"Unknown error. [param={Action}]"),
        };
    }

    public override string ToString()
    {
        return _json;
    }

    private static async Task<string> GetTokenAsync(IHttpClient client, string scope, CancellationToken token)
    {
        try
        {
            var url = $"https://auth.docker.io/token?service=registry.docker.io&scope={scope}";
            return await client.GetContentAsStringAsync(url, token).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new ContainerDownloaderException("Failed to get a token.", ex);
        }
    }
}