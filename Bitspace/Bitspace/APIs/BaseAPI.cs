using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.Core;
using Newtonsoft.Json;

namespace Bitspace.APIs
{
    public class BaseAPI
    {
        protected readonly IHttpClient _client;
        protected int TimeoutSeconds = 10;

        [ExcludeFromCodeCoverage]
        protected BaseAPI(
            IHttpClient client,
            IApiKeyManagerService keyManagerService,
            API_Endpoints api)
        {
            _client = client;

            _client.SetTimeout(TimeoutSeconds);
            ApiKey = keyManagerService.GetKey(api);
        }

        protected string ApiKey { get; }

        protected async Task<Response<T>> ToResponse<T>(HttpResponseMessage rawResponse) where T : class, new()
        {
            var content = await rawResponse.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content) ?? new T();
            var response = new Response<T>(data, rawResponse.StatusCode, rawResponse.RequestMessage.Method.Method, rawResponse.IsSuccessStatusCode);
            return response;
        }
    }
}