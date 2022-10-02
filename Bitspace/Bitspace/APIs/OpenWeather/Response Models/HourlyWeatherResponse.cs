using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
    public class HourlyWeatherResponse
    {
        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        [JsonProperty("list")]
        public ForecastListObjectResponse[] List { get; set; }

        [JsonProperty("city")]
        public CityResponseModel City { get; set; }
    }
}