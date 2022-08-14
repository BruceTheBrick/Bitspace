using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage
]
public class RainResponseModel
{
    [JsonProperty("1h")]
    public double RainVolume { get; set; }
}