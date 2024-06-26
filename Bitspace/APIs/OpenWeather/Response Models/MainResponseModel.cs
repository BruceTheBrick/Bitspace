﻿using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage]
public class MainResponseModel
{
    [JsonProperty("temp")]
    public double Temperature { get; set; }

    [JsonProperty("feels_like")]
    public double FeelsLike { get; set; }

    [JsonProperty("temp_min")]
    public double TemperatureMin { get; set; }

    [JsonProperty("temp_max")]
    public double TemperatureMax { get; set; }

    [JsonProperty("pressure")]
    public int Pressure { get; set; }

    [JsonProperty("sea_level")]
    public int SeaLevel { get; set; }

    [JsonProperty("grnd_level")]
    public int GroundLevel { get; set; }

    [JsonProperty("humidity")]
    public int Humidity { get; set; }

    [JsonProperty("temp_kf")]
    public double Temperature_KF { get; set; }
}