using Newtonsoft.Json;

namespace Bitspace.APIs;

public class OpenWeatherAPI : BaseApi, IOpenWeatherApi
{
    private const string Endpoint = "https://api.openweathermap.org";

    public OpenWeatherAPI(
        IHttpClient client,
        IApiKeyManagerService keyManagerService)
        : base(client, keyManagerService, ApiEndpoints.OpenWeather)
    {
    }

    public async Task<Response<CurrentWeatherResponse>> GetCurrentWeather(CurrentWeatherRequest request)
    {
        var url = new Uri($"{Endpoint}/data/2.5/weather?units=metric&lat={request.Latitude}&lon={request.Longitude}&appid={ApiKey}");
        var rawResponse = await Client.GetAsync(url);
        return await ToResponse<CurrentWeatherResponse>(rawResponse);
    }

    public async Task<Response<HourlyWeatherResponse>> GetHourlyWeather(HourlyForecastRequest request)
    {
        var url = new Uri($"{Endpoint}/data/2.5/forecast?units=metric&lat={request.Latitude}&lon={request.Longitude}&appid={ApiKey}");
        var rawResponse = await Client.GetAsync(url);
        return await ToResponse<HourlyWeatherResponse>(rawResponse);
    }

    public async Task<Response<ReverseGeocodeResponseItemModel[]>> GetCurrentLocationName(ReverseGeocodeRequest request)
    {
        var url = new Uri($"{Endpoint}/geo/1.0/reverse?lat={request.Latitude}&lon={request.Longitude}&appid={ApiKey}");
        var rawResponse = await Client.GetAsync(url);
        var content = await rawResponse.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<ReverseGeocodeResponseItemModel[]>(content) ??
                   Array.Empty<ReverseGeocodeResponseItemModel>();
        var response = new Response<ReverseGeocodeResponseItemModel[]>(
            data,
            rawResponse.StatusCode,
            rawResponse.RequestMessage?.Method.Method,
            rawResponse.IsSuccessStatusCode);
        return response;
    }
}