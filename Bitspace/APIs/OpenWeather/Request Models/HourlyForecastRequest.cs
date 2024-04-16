using System.Diagnostics.CodeAnalysis;

namespace Bitspace.APIs;

[ExcludeFromCodeCoverage]
public class HourlyForecastRequest
{
    public HourlyForecastRequest()
    {
        }

    public HourlyForecastRequest(double latitude, double longitude)
    {
            Latitude = latitude;
            Longitude = longitude;
        }

    public HourlyForecastRequest(Location location)
    {
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}