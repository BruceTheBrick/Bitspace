using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.Services.APIKeyManager;
using Newtonsoft.Json;

namespace Bitspace.APIs;

public class BaseAPI
{
    protected string ApiKey { get; }
    protected int TimeoutSeconds = 10;

    protected readonly IHttpClient _client;
    protected readonly IApiKeyManagerService _keyManagerService;

    protected BaseAPI(
        IHttpClient client,
        IApiKeyManagerService keyManagerService,
        API_Endpoints api)
    {
        _client = client;
        _keyManagerService = keyManagerService;

        _client.SetTimeout(TimeoutSeconds);
        ApiKey = _keyManagerService.GetKey(api);
    }

    protected async Task<Response<T>> ToResponse<T>(HttpResponseMessage rawResponse) where T : class
    {
        var response = new Response<T>
            {
                Method = StringToMethod(rawResponse.RequestMessage.Method.Method), StatusCode = rawResponse.StatusCode,
                IsSuccess = rawResponse.IsSuccessStatusCode,
            };
        var content = await rawResponse.Content.ReadAsStringAsync();
        response.Data = JsonConvert.DeserializeObject<T>(content);
        return response;
    }

    private HttpMethod StringToMethod(string methodString)
    {
        return methodString switch
        {
            "GET" => HttpMethod.Get,
            "POST" => HttpMethod.Post,
            "PUT" => HttpMethod.Put,
            "HEAD" => HttpMethod.Head,
            "DELETE" => HttpMethod.Delete,
            "PATCH" => HttpMethod.Patch,
            "OPTIONS" => HttpMethod.Options,
        };
    }
}