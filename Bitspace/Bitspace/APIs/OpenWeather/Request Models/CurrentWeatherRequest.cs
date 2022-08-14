using Bitspace.Services;

namespace Bitspace.APIs;

public class CurrentWeatherRequest
{
    public CurrentWeatherRequest()
    {
    }

    public CurrentWeatherRequest(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public CurrentWeatherRequest(LocationModel location)
    {
        Latitude = location.Latitude;
        Longitude = location.Longitude;
    }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}