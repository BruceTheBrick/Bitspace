using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage]
public class SnowResponseModel
{
    [JsonProperty("1h")]
    public double SnowVolume { get; set; }
}