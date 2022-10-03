using System.Threading.Tasks;
using Bitspace.APIs;

namespace Bitspace.Services
{
    public interface ICurrentWeatherService
    {
        public Task<HourlyForecastViewModel> GetHourlyForecast();
    }
}