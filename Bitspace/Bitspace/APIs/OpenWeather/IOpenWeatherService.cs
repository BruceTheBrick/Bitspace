using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Responses;

namespace Bitspace.APIs.OpenWeather
{
    public interface IOpenWeatherService
    {
        Task<CurrentWeatherResponse> GetCurrentWeather();
    }
}
