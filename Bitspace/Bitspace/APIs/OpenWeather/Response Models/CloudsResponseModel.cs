using Newtonsoft.Json;

namespace Bitspace.APIs
{
    public class CloudsResponseModel
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
