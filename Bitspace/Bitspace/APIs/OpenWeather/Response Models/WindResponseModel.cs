using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
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
