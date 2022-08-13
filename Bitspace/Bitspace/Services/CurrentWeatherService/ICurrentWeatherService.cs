using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.ViewModels;

namespace Bitspace.Services.CurrentWeatherService;

public interface ICurrentWeatherService
{
    public Task<CurrentWeatherViewModel> GetCurrentWeather();
}