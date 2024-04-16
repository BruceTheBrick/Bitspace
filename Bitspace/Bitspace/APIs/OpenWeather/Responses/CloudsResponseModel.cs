using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Responses
{
    public class CloudsResponseModel
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
