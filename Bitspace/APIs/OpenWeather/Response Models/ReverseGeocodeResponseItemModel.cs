﻿using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage]
public class ReverseGeocodeResponseItemModel
{
    public ReverseGeocodeResponseItemModel()
    {
    }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("local_names")]
    public LocalNamesResponseModel LocalNames { get; set; }

    [JsonProperty("lat")]
    public double Latitude { get; set; }

    [JsonProperty("lon")]
    public double Longitude { get; set; }

    [JsonProperty("country")]
    public string CountryCode { get; set; }
}