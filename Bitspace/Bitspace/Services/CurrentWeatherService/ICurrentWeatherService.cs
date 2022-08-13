using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Models;

namespace Bitspace.Services.CurrentWeatherService;

public interface ICurrentWeatherService
{
    public Task<CurrentWeatherViewModel> GetCurrentWeather();
}