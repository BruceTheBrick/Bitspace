using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bitspace.APIs
{
    public class ExtendedHttpClient : IHttpClient
    {
        private HttpClient _client;

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

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return await _client.GetAsync(uri);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
    }
}
