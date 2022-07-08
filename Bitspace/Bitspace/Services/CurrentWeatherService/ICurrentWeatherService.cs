using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Models;

namespace Bitspace.Services.CurrentWeatherService;

public interface ICurrentWeatherService
{
    public Task<CurrentWeatherViewModel> GetCurrentWeather();
    public Task<string> GetSuburb();
    public Task<double> GetTemperature();
    public Task<double> GetHumidity();
    public Task<double> GetWindSpeed();
    public Task<double> GetPressure();
}