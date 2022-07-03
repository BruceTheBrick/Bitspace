using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Response_Models;
using Bitspace.Services.DeviceLocation;
using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather
{
    public class OpenWeatherAPI : IOpenWeatherAPI
    {
        private readonly IHttpClient _client;
        private readonly IDeviceLocation _deviceLocationService;
        public OpenWeatherAPI(IHttpClient client, IDeviceLocation deviceLocationService)
        {
            _client = client;
            _deviceLocationService = deviceLocationService;
        }

        public async Task<CurrentWeatherResponse> GetCurrentWeather()
        {
            var location = await _deviceLocationService.GetCurrentLocation(LocationAccuracy.High, 5);
            var key = "2366c9edf1524154fa6982430cacdb30";
            var url = $"https://api.openweathermap.org/data/2.5/weather?units=metric&lat={location.Latitude}&lon={location.Longitude}&appid={key}";
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CurrentWeatherResponse>(content);
        }
    }
}
