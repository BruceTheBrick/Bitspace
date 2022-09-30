using Newtonsoft.Json;

namespace Bitspace.APIs
{
    public class ForecastListObjectResponse
    {
        [JsonProperty("dt")]
        public int DT { get; set; }

        [JsonProperty("main")]
        public MainResponseModel Main { get; set; }

        [JsonProperty("weather")]
        public WeatherResponseModel[] Weather { get; set; }

        [JsonProperty("clouds")]
        public CloudsResponseModel Clouds { get; set; }

        [JsonProperty("wind")]
        public WindResponseModel Wind { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("pop")]
        public double ProbabilityOfPrecipitation { get; set; }

        [JsonProperty("rain")]
        public RainResponseModel Rain { get; set; }

        [JsonProperty("sys")]
        public SystemResponseModel System { get; set; }

        [JsonProperty("dt_txt")]
        public string DateTimeText { get; set; }
    }
}