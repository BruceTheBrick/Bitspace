namespace Bitspace.APIs;

public interface IHttpClient
{
    public void SetTimeout(int seconds);
    public int GetTimeout();
    Task<HttpResponseMessage> GetAsync(Uri uri);

    Task<HttpResponseMessage> GetAsync(string url);
}