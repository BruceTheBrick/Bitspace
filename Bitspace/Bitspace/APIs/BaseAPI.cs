using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.Services.APIKeyManager;
using Newtonsoft.Json;

namespace Bitspace.APIs;

public class BaseAPI
{
    protected readonly IHttpClient _client;
    protected int TimeoutSeconds = 10;

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

    protected async Task<Response<T>> ToResponse<T>(HttpResponseMessage rawResponse) where T : class
    {
        var content = await rawResponse.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<T>(content);
        var response = new Response<T>(data, rawResponse.StatusCode, StringToMethod(rawResponse.RequestMessage.Method.Method), rawResponse.IsSuccessStatusCode);
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