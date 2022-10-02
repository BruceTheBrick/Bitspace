using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
    public class ReverseGeocodeViewModel
    {
        public ReverseGeocodeViewModel()
        {
        }

        public ReverseGeocodeViewModel(ReverseGeocodeResponseItemModel[] response)
        {
            Name = response.First().Name;
            Latitude = response.First().Latitude;
            Longitude = response.First().Longitude;
            CountryCode = response.First().CountryCode;
        }

        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CountryCode { get; set; }
    }
}