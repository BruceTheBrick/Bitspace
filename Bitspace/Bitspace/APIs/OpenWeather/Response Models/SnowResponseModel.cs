using Newtonsoft.Json;

namespace Bitspace.APIs;

public class SnowResponseModel
{
    [JsonProperty("1h")]
    public double SnowVolume { get; set; }
}