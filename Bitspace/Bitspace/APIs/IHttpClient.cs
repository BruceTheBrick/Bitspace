using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bitspace.APIs
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(Uri uri);

        Task<HttpResponseMessage> GetAsync(string url);
    }
}
