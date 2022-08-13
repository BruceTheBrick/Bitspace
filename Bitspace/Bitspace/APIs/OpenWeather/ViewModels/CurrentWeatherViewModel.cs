using System.Collections.Generic;
using System.Linq;
using Bitspace.APIs.OpenWeather.Response_Models;

namespace Bitspace.APIs.OpenWeather.ViewModels;

public class CurrentWeatherViewModel
{
    public CurrentWeatherViewModel(CurrentWeatherResponse response)
    {
        IconUrl = GetIconURL(response.Weather.FirstOrDefault()?.Icon, 4);
        Suburb = response.Name;
        Temperature = response.Main.Temperature;
        FeelsLike = response.Main.FeelsLike;
        Humidity = response.Main.Humidity;
        Pressure = response.Main.Pressure;
        WindSpeed = response.Wind.Speed;
        Description = response.Weather?[0].Description;
        DescriptionList = GetDescriptionsFromResponse(response);
    }

    public string IconUrl { get; set; }
    public string Suburb { get; set; }
    public double Temperature { get; set; }
    public double FeelsLike { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public double Pressure { get; set; }
    public string Description { get; set; }
    public List<string> DescriptionList { get; set; }

    private string GetIconURL(string iconId, int size = 2)
    {
        if (size is <= 0 or > 4)
        {
            return string.Empty;
        }

        var imgSize = size == 1 ? string.Empty : $"@{size}x";
        return $"http://openweathermap.org/img/wn/{iconId}{imgSize}.png";
    }

    private List<string> GetDescriptionsFromResponse(CurrentWeatherResponse response)
    {
        return response.Weather.Select(weather => weather.Description.ToUpper()).ToList();
    }
}