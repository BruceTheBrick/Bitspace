using Newtonsoft.Json;

namespace Bitspace.APIs;

public class RainResponseModel
{
    [JsonProperty("1h")]
    public double RainVolume { get; set; }
}