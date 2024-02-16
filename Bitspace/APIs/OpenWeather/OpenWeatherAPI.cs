using Newtonsoft.Json;

namespace Bitspace.APIs;

public class OpenWeatherAPI : BaseAPI, IOpenWeatherAPI
{
    private const string Endpoint = "https://api.openweathermap.org";

    public OpenWeatherAPI(
        IHttpClient client,
        IApiKeyManagerService keyManagerService)
        : base(client, keyManagerService, API_Endpoints.OPEN_WEATHER)
    {
    }

    public async Task<Response<CurrentWeatherResponse>> GetCurrentWeather(CurrentWeatherRequest request)
    {
        var url =
            $"{Endpoint}/data/2.5/weather?units=metric&lat={request.Latitude}&lon={request.Longitude}&appid={ApiKey}";
        var rawResponse = await _client.GetAsync(url);
        return await ToResponse<CurrentWeatherResponse>(rawResponse);
    }

    public async Task<Response<HourlyWeatherResponse>> GetHourlyWeather(HourlyForecastRequest request)
    {
        var url =
            $"{Endpoint}/data/2.5/forecast?units=metric&lat={request.Latitude}&lon={request.Longitude}&appid={ApiKey}";
        var rawResponse = await _client.GetAsync(url);
        return await ToResponse<HourlyWeatherResponse>(rawResponse);
    }

    public async Task<Response<ReverseGeocodeResponseItemModel[]>> GetCurrentLocationName(ReverseGeocodeRequest request)
    {
        var url = $"{Endpoint}/geo/1.0/reverse?lat={request.Latitude}&lon={request.Longitude}&appid={ApiKey}";
        var rawResponse = await _client.GetAsync(url);
        var content = await rawResponse.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<ReverseGeocodeResponseItemModel[]>(content) ??
                   Array.Empty<ReverseGeocodeResponseItemModel>();
        var response = new Response<ReverseGeocodeResponseItemModel[]>(data, rawResponse.StatusCode,
            rawResponse.RequestMessage.Method.Method, rawResponse.IsSuccessStatusCode);
        return response;
    }
}