using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Responses
{
    public class WindResponseModel
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Degrees { get; set; }

        [JsonProperty("gust")]
        public double Gust { get; set; }
    }
}
