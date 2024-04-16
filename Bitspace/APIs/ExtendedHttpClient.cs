using System.Diagnostics.CodeAnalysis;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage]
public class ExtendedHttpClient : IHttpClient
{
    private readonly HttpClient _client;

    public ExtendedHttpClient()
    {
        _client = new HttpClient();
    }

    public void SetTimeout(int seconds)
    {
        _client.Timeout = TimeSpan.FromSeconds(seconds);
    }

    public int GetTimeout()
    {
        return (int)_client.Timeout.TotalSeconds;
    }

    public Task<HttpResponseMessage> GetAsync(Uri uri)
    {
        return _client.GetAsync(uri);
    }

    public Task<HttpResponseMessage> GetAsync(string url)
    {
        return _client.GetAsync(url);
    }
}