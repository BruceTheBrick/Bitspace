using System.Threading.Tasks;
using Bitspace.APIs;
using Bitspace.Services;

namespace Bitspace.APIs
{
    public class OpenWeatherAPI : BaseAPI, IOpenWeatherAPI
    {
        private const string Endpoint = "https://api.openweathermap.org";

        public OpenWeatherAPI(
            IHttpClient client,
            IApiKeyManagerService keyManagerService)
            : base(client, keyManagerService, API_Endpoints.OPEN_WEATHER)
        {
        }

        public async Task<Response<CurrentWeatherResponse>> GetCurrentWeather(CurrentWeatherRequest request)
        {
            var url = $"{Endpoint}/data/2.5/weather?units=metric&lat={request.Latitude}&lon={request.Longitude}&appid={ApiKey}";
            var rawResponse = await _client.GetAsync(url);
            return await ToResponse<CurrentWeatherResponse>(rawResponse);
        }

        // public async Task<Response<HourlyWeatherResponse>> GetHourlyWeather()
        // {
        //     
        // }
    }
}
