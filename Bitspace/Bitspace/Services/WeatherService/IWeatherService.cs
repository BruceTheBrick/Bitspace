using System.Threading.Tasks;
using Bitspace.APIs;

namespace Bitspace.Services;

public interface ICurrentWeatherService
{
    public Task<CurrentWeatherViewModel> GetCurrentWeather();

    public Task<HourlyForecastViewModel> GetHourlyForecast();

    public Task<string> GetLocationName();
}