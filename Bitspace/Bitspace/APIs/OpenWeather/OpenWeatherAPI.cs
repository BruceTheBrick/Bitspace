using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Response_Models;
using Bitspace.Services.DeviceLocation;

namespace Bitspace.APIs.OpenWeather
{
    public class OpenWeatherAPI : BaseAPI, IOpenWeatherAPI
    {
        const string key = "2366c9edf1524154fa6982430cacdb30";

        private readonly IDeviceLocation _deviceLocationService;
        public OpenWeatherAPI(IHttpClient client, IDeviceLocation deviceLocationService)
            : base(client)
        {
            _deviceLocationService = deviceLocationService;
        }

        public async Task<Response<CurrentWeatherResponse>> GetCurrentWeather()
        {
            try
            {
                var location = await _deviceLocationService.GetCurrentLocation(LocationAccuracy.High);
                var url = $"https://api.openweathermap.org/data/2.5/weather?units=metric&lat={location.Latitude}&lon={location.Longitude}&appid={key}";
                var rawResponse = await _client.GetAsync(url);
                return await ToResponse<CurrentWeatherResponse>(rawResponse);
            }
            catch (HttpRequestException timeoutException)
            {
                var response = new Response<CurrentWeatherResponse>
                    {
                        StatusCode = (HttpStatusCode)404,
                        ErrorMessage = timeoutException.Message,
                        IsSuccess = false,
                    };
                return response;
            }
        }
    }
}
