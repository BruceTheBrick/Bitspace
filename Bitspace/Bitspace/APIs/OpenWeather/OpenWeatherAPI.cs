using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Response_Models;
using Bitspace.Services.APIKeyManager;
using Bitspace.Services.DeviceLocation;

namespace Bitspace.APIs.OpenWeather
{
    public class OpenWeatherAPI : BaseAPI, IOpenWeatherAPI
    {
        private readonly IDeviceLocation _deviceLocationService;
        public OpenWeatherAPI(
            IDeviceLocation deviceLocationService,
            IHttpClient client,
            IApiKeyManagerService keyManagerService)
            : base(client, keyManagerService, API_Endpoints.OPEN_WEATHER)
        {
            _deviceLocationService = deviceLocationService;
        }

        public async Task<Response<CurrentWeatherResponse>> GetCurrentWeather()
        {
            var location = await _deviceLocationService.GetCurrentLocation(LocationAccuracy.High);
            var url = $"https://api.openweathermap.org/data/2.5/weather?units=metric&lat={location.Latitude}&lon={location.Longitude}&appid={API_KEY}";
            var rawResponse = await _client.GetAsync(url);
            return await ToResponse<CurrentWeatherResponse>(rawResponse);
        }
    }
}
