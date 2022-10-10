using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
    public class RainResponseModel
    {
        [JsonProperty("1h")]
        public double RainVolume { get; set; }

        [JsonProperty("3h")]
        public double RainVolume3H { get; set; }
    }
}