using System.Net.Http;
using System.Threading.Tasks;
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

    protected readonly int TimeoutSeconds = 10;

    protected readonly IHttpClient _client;

    protected BaseAPI(IHttpClient client)
    {
        _client = client;
        _client.SetTimeout(TimeoutSeconds);
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