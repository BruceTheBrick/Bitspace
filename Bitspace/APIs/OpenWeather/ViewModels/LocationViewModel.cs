namespace Bitspace.APIs;

public class LocationViewModel
{
    public LocationViewModel()
    {
    }

    public LocationViewModel(ReverseGeocodeResponseItemModel response)
    {
        Name = response.Name;
        Latitude = response.Latitude;
        Longitude = response.Longitude;
        CountryCode = response.CountryCode;
    }

    public LocationViewModel(string name, double latitude, double longitude, string countryCode)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        CountryCode = countryCode;
    }

    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string CountryCode { get; set; }
}