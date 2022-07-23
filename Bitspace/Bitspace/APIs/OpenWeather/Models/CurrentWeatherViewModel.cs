using System.Collections.Generic;

namespace Bitspace.APIs.OpenWeather.Models;

public class CurrentWeatherViewModel
{
    public string IconUrl { get; set; }
    public string Suburb { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public double Pressure { get; set; }
    public string Description { get; set; }
    public List<string> DescriptionList { get; set; }
}