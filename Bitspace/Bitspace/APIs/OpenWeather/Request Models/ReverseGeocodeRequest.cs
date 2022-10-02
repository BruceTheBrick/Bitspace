using System.Diagnostics.CodeAnalysis;
using Bitspace.Services;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
    public class ReverseGeocodeRequest
    {
        public ReverseGeocodeRequest()
        {
        }

        public ReverseGeocodeRequest(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public ReverseGeocodeRequest(LocationModel location)
        {
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}