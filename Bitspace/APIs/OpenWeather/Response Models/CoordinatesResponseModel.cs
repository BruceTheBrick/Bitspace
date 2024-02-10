using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage]
public class CoordinatesResponseModel
{
    [JsonProperty("lon")]
    public double Longitude { get; set; }

    [JsonProperty("lat")]
    public double Latitude { get; set; }
}