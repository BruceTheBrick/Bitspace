namespace Bitspace.APIs;

public interface IOpenWeatherAPI
{
    Task<Response<CurrentWeatherResponse>> GetCurrentWeather(CurrentWeatherRequest request);
    Task<Response<HourlyWeatherResponse>> GetHourlyWeather(HourlyForecastRequest request);
    Task<Response<ReverseGeocodeResponseItemModel[]>> GetCurrentLocationName(ReverseGeocodeRequest request);
}