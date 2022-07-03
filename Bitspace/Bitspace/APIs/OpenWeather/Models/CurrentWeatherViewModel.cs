namespace Bitspace.APIs.OpenWeather.Models;

public class CurrentWeatherViewModel
{
    public string Suburb { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public double Pressure { get; set; }
}