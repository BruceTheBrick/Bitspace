using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Response_Models
{
    public class SystemResponseModel
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public double Sunrise { get; set; }

        [JsonProperty("sunset")]
        public double Sunset { get; set; }
    }
}
