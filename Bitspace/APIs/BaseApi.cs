using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs;

public class BaseApi
{
    [ExcludeFromCodeCoverage]
    protected BaseApi(
        IHttpClient client,
        IApiKeyManagerService keyManagerService,
        ApiEndpoints api)
    {
        Client = client;

        Client.SetTimeout(TimeoutSeconds);
        ApiKey = keyManagerService.GetKey(api);
    }

    protected IHttpClient Client { get; }
    protected string ApiKey { get; }
    protected int TimeoutSeconds => 10;

    protected async Task<Response<T>> ToResponse<T>(HttpResponseMessage rawResponse) where T : class, new()
    {
        var content = await rawResponse.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<T>(content) ?? new T();
        var response = new Response<T>(
            data,
            rawResponse.StatusCode,
            rawResponse.RequestMessage?.Method.Method,
            rawResponse.IsSuccessStatusCode);
        return response;
    }
}