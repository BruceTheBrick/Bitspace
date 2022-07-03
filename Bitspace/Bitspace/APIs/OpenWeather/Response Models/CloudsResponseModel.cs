using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Response_Models
{
    public class CloudsResponseModel
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
