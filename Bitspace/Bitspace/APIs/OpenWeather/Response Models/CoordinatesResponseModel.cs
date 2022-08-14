using Newtonsoft.Json;

namespace Bitspace.APIs
{
    public class CoordinatesResponseModel
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
