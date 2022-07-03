using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Response_Models
{
    public class CoordinatesResponseModel
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
