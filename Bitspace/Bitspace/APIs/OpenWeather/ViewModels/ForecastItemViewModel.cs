using System;
using System.Linq;
using Bitspace.Interfaces;
using Humanizer;

namespace Bitspace.APIs;

public class ForecastItemViewModel : IAccessibility
{
    public ForecastItemViewModel()
    {
    }

    public ForecastItemViewModel(ListObjectResponse response)
    {
        DateTime = InitDateTime(response.DT);
        DisplayText = GetDisplayText();
        DisplayDateTime = GetDisplayDateTime(DateTime);
        Temperature = Math.Round(response.Main.Temperature, 2);
        FeelsLike = Math.Round(response.Main.FeelsLike, 2);
        RainChance = Math.Round(response.RainChance, 2);
        Humidity = response.Main.Humidity;
        TemperatureMax = Math.Round(response.Main.TemperatureMax, 2);
        TemperatureMin = Math.Round(response.Main.TemperatureMin, 2);
        Description = response.Weather.First().Main;
        ExtendedDescription = response.Weather.First().Description.Humanize();
        WindSpeed = Math.Round(response.Wind.Speed, 2);
        GustSpeed = Math.Round(response.Wind.Gust, 2);
    }

    public DateTime DateTime { get; set; }
    public string DisplayText { get; set; }
    public string DisplayDateTime { get; set; }
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
    public string AccessibilityName => GetAccessibilityName();

    private DateTime InitDateTime(int utcTime)
    {
        return DateTime.UnixEpoch.AddSeconds(utcTime);
    }

    private string GetDisplayText()
    {
        var dayName = DateTime.ToString("dddd");
        var shortMonth = DateTime.ToString("MMM");
        var date = DateTime.Day;
        return $"{dayName}, {date} {shortMonth}";
    }

    private string GetDisplayDateTime(DateTime datetime)
    {
        return datetime.ToString("ddd, dd MMM\nhh:mmtt");
    }

    private string GetAccessibilityName()
    {
        return string.Empty;
    }
}