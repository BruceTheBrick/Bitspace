using System;
using System.Linq;
using Bitspace.Extensions;
using Bitspace.Interfaces;
using Humanizer;

namespace Bitspace.APIs;

public class ForecastItemViewModel : IAccessibility
{
    public ForecastItemViewModel()
    {
    }

    public ForecastItemViewModel(ForecastListObjectResponse response)
    {
        DateTime = InitDateTime(response.DT);
        DisplayText = DateTime.ToDisplayString();
        DisplayDateTime = DateTime.ToDisplayString();
        Temperature = Math.Round(response.Main.Temperature, 2);
        FeelsLike = Math.Round(response.Main.FeelsLike, 2);
        RainChance = GetRainChance(response.Rain);
        Humidity = response.Main.Humidity;
        TemperatureMax = Math.Round(response.Main.TemperatureMax, 2);
        TemperatureMin = Math.Round(response.Main.TemperatureMin, 2);
        Description = response.Weather.First().Main;
        ExtendedDescription = response.Weather.First().Description.Humanize();
        WindSpeed = Math.Round(response.Wind.Speed, 2);
        GustSpeed = Math.Round(response.Wind.Gust, 2);
    }

    private double GetRainChance(RainResponseModel responseRain)
    {
        if (responseRain == null)
        {
            return 0.0;
        }

        return Math.Round(
            responseRain.RainVolume != default
            ? responseRain.RainVolume
            : responseRain.RainVolume3H, 2);
    }

    public DateTime DateTime { get; }
    public string DisplayText { get; }
    public string DisplayDateTime { get; set; }
    public double Temperature { get; set; }
    public double FeelsLike { get; }
    public double RainChance { get; }
    public double Humidity { get; }
    public double TemperatureMax { get; set; }
    public double TemperatureMin { get; set; }
    public string Description { get; }
    public string ExtendedDescription { get; set; }
    public double WindSpeed { get; }
    public double GustSpeed { get; }
    public string AccessibilityName => GetAccessibilityName();

    private DateTime InitDateTime(int utcTime)
    {
        return DateTime.UnixEpoch.AddSeconds(utcTime);
    }

    private string GetAccessibilityName()
    {
        return string.Empty;
    }
}