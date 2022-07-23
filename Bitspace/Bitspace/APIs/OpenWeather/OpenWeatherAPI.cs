using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Response_Models;
using Bitspace.Services.APIKeyManager;
using Bitspace.Services.DeviceLocation;

namespace Bitspace.APIs.OpenWeather
{
    public class OpenWeatherAPI : BaseAPI, IOpenWeatherAPI
    {
        private readonly IDeviceLocation _deviceLocationService;

        private const string Endpoint = "https://api.openweathermap.org";

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
            var url = $"{Endpoint}/data/2.5/weather?units=metric&lat={location.Latitude}&lon={location.Longitude}&appid={API_KEY}";
            var rawResponse = await _client.GetAsync(url);
            return await ToResponse<CurrentWeatherResponse>(rawResponse);
        }

        public string GetIconURL(string iconId, int size = 2)
        {
            if (size is <= 0 or > 4)
            {
                return string.Empty;
            }

            var imgSize = size == 1 ? string.Empty : $"@{size}x";
            return $"http://openweathermap.org/img/wn/{iconId}{imgSize}.png";
        }
    }
}
