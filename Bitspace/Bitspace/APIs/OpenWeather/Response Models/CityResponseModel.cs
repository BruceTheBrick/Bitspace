using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
    public class CityResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public CoordinatesResponseModel Coordinates { get; set; }

        [JsonProperty("country")]
        public string CountryCode { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("timezone")]
        public int TimezoneShift { get; set; }

        [JsonProperty("sunrise")]
        public int SunriseTime { get; set; }

        [JsonProperty("sunset")]
        public int SunsetTime { get; set; }
    }
}