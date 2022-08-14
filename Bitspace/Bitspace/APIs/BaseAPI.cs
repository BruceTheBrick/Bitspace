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

    protected async Task<Response<T>> ToResponse<T>(HttpResponseMessage rawResponse) where T : class, new()
    {
        var content = await rawResponse.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<T>(content) ?? new T();
        var response = new Response<T>(data, rawResponse.StatusCode, StringToMethod(rawResponse.RequestMessage.Method.Method), rawResponse.IsSuccessStatusCode);
        return response;
    }

    private HttpMethod StringToMethod(string methodString)
    {
        switch (methodString)
        {
            case "GET":
                return HttpMethod.Get;
            case "POST":
                return HttpMethod.Post;
            case "PUT":
                return HttpMethod.Put;
            case "HEAD":
                return HttpMethod.Head;
            case "DELETE":
                return HttpMethod.Delete;
            case "PATCH":
                return HttpMethod.Patch;
            case "OPTIONS":
                return HttpMethod.Options;
        }

        return null;
    }
}