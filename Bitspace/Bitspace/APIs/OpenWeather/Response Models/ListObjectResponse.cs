using Newtonsoft.Json;

namespace Bitspace.APIs.OpenWeather.Response_Models;

public class ListObjectResponse
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
    public double Pop { get; set; }

    [JsonProperty("sys")]
    public SystemResponseModel System { get; set; }

    [JsonProperty("dt_txt")]
    public string DateTimeText { get; set; }
}