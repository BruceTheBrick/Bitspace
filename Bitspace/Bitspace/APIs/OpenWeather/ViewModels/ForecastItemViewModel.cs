using System;
using System.Linq;

namespace Bitspace.APIs;

public class ForecastItemViewModel
{
    public ForecastItemViewModel()
    {
    }

    public ForecastItemViewModel(ListObjectResponse response)
    {
        DateTime = DateTime.Now.AddSeconds(response.DT);
        Temperature = response.Main.Temperature;
        FeelsLike = response.Main.FeelsLike;
        RainChance = response.RainChance;
        Humidity = response.Main.Humidity;
        TemperatureMax = response.Main.TemperatureMax;
        TemperatureMin = response.Main.TemperatureMin;
        Description = response.Weather.First().Description;
        ExtendedDescription = response.Weather.First().Main;
        WindSpeed = response.Wind.Speed;
        GustSpeed = response.Wind.Gust;
    }

    public DateTime DateTime { get; set; }
    public double Temperature { get; set; }
    public double FeelsLike { get; set; }
    public double RainChance { get; set; }
    public double Humidity { get; set; }
    public double TemperatureMax { get; set; }
    public double TemperatureMin { get; set; }
    public string Description { get; set; }
    public string ExtendedDescription { get; set; }
    public double WindSpeed { get; set; }
    public double GustSpeed { get; set; }
}