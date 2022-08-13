using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Request_Models;
using Bitspace.APIs.OpenWeather.Response_Models;

namespace Bitspace.APIs.OpenWeather
{
    public interface IOpenWeatherAPI
    {
        Task<Response<CurrentWeatherResponse>> GetCurrentWeather(CurrentWeatherRequest request);
    }
}
