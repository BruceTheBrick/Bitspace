using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Responses
{
    public class CoordinatesResponseModel
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
