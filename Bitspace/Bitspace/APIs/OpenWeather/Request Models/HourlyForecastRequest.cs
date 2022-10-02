using System.Diagnostics.CodeAnalysis;
using Bitspace.Services;

namespace Bitspace.APIs
{
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

        public HourlyForecastRequest(LocationModel location)
        {
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}