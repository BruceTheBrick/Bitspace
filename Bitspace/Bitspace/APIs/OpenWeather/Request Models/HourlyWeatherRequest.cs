using Bitspace.Services;

namespace Bitspace.APIs;

public class HourlyWeatherRequest
{
    public HourlyWeatherRequest()
    {
    }

    public HourlyWeatherRequest(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public HourlyWeatherRequest(LocationModel location)
    {
        Latitude = location.Latitude;
        Longitude = location.Longitude;
    }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}