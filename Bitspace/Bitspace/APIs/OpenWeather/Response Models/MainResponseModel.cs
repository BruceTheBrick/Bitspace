using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Response_Models
{
    public class MainResponseModel
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TemperatureMin { get; set; }

        [JsonProperty("temp_max")]
        public double TemperatureMax { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
