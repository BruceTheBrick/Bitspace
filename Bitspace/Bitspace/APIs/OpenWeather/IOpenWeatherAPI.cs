using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Response_Models;

namespace Bitspace.APIs.OpenWeather
{
    public interface IOpenWeatherAPI
    {
        Task<Response<CurrentWeatherResponse>> GetCurrentWeather();
        string GetIconURL(string iconId, int size = 2);
    }
}
