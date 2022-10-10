using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories;

public static class OpenWeatherAPIRequestFactory
{
    public static CurrentWeatherRequest CurrentWeatherRequest()
    {
        return new Faker<CurrentWeatherRequest>()
            .RuleFor(x => x.Latitude, f => f.Random.Double(-90, 90))
            .RuleFor(x => x.Longitude, f => f.Random.Double(-180, 180))
            .Generate();
    }

    public static HourlyForecastRequest HourlyForecastRequest()
    {
        return new Faker<HourlyForecastRequest>()
            .RuleFor(x => x.Latitude, f => f.Random.Double(-90, 90))
            .RuleFor(x => x.Longitude, f => f.Random.Double(-180, 180))
            .Generate();
    }

    public static ReverseGeocodeRequest CurrentLocationNameRequest()
    {
        return new Faker<ReverseGeocodeRequest>()
            .RuleFor(x => x.Latitude, f => f.Random.Double(-90, 90))
            .RuleFor(x => x.Longitude, f => f.Random.Double(-180, 180))
            .Generate();
    }
}