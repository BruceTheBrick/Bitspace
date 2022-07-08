using Bitspace.APIs.OpenWeather.Response_Models;
using Bogus;

namespace Bitspace.Tests.Factories.APIs.OpenWeatherAPI;

public static class CoordinateResponseModelFactory
{
    public static CoordinatesResponseModel GetModel()
    {
        return GetModels(1).First();
    }

    public static CoordinatesResponseModel[] GetModels(int count = 5)
    {
        return new Faker<CoordinatesResponseModel>()
            .RuleFor(x => x.Latitude, f => f.Random.Double(-90, 90))
            .RuleFor(x => x.Longitude, f => f.Random.Double(-180, 180))
            .Generate(count).ToArray();
    }
}