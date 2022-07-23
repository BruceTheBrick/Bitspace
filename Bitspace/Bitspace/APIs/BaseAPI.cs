using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.Services.APIKeyManager;
using Newtonsoft.Json;

namespace Bitspace.APIs;

public class BaseAPI
{
    public enum HTTPMethod
    {
        GET,
        POST,
        PUT,
        HEAD,
        DELETE,
        PATCH,
        OPTIONS,
        INVALID,
    }

    protected string API_KEY { get; }
    protected readonly int TimeoutSeconds = 10;
    protected API_Endpoints ApiType { get; }

    protected readonly IHttpClient _client;
    protected readonly IApiKeyManagerService _keyManagerService;

    protected BaseAPI(
        IHttpClient client,
        IApiKeyManagerService keyManagerService,
        API_Endpoints api)
    {
        _client = client;
        _keyManagerService = keyManagerService;
        ApiType = api;

        _client.SetTimeout(TimeoutSeconds);
        API_KEY = _keyManagerService.GetKey(api);
    }

    protected async Task<Response<T>> ToResponse<T>(HttpResponseMessage rawResponse) where T : class
    {
        var response = new Response<T>();
        response.Method = StringToMethod(rawResponse.RequestMessage.Method.Method);
        response.StatusCode = rawResponse.StatusCode;
        response.IsSuccess = rawResponse.IsSuccessStatusCode;
        var content = await rawResponse.Content.ReadAsStringAsync();
        response.Data = JsonConvert.DeserializeObject<T>(content);
        return response;
    }

    private HTTPMethod StringToMethod(string methodString)
    {
        return methodString switch
        {
            "GET" => HTTPMethod.GET,
            "POST" => HTTPMethod.POST,
            "PUT" => HTTPMethod.PUT,
            "HEAD" => HTTPMethod.HEAD,
            "DELETE" => HTTPMethod.DELETE,
            "PATCH" => HTTPMethod.PATCH,
            "OPTIONS" => HTTPMethod.OPTIONS,
            _ => HTTPMethod.INVALID
        };
    }
}