using Newtonsoft.Json;

namespace Bitspace.APIs
{
    public class LocalNamesResponseModel
    {
        [JsonProperty("ascii")]
        public string Ascii { get; set; }

        [JsonProperty("en")]
        public string English { get; set; }
    }
}