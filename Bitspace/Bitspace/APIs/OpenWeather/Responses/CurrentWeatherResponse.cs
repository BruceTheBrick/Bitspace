using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Responses
{
    public class CurrentWeatherResponse
    {
        [JsonProperty("coord")]
        public CoordinatesResponseModel Coordinates { get; set; }

        [JsonProperty("weather")]
        public WeatherResponseModel[] Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public MainResponseModel Main { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("wind")]
        public WindResponseModel Wind { get; set; }

        [JsonProperty("clouds")]
        public CloudsResponseModel Clouds { get; set; }

        [JsonProperty("dt")]
        public double DT { get; set; }

        [JsonProperty("sys")]
        public SystemResponseModel System { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("id")]
        public double Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }
    }
}
