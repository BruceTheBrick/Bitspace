using System.Linq;
using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories;

public static class CityResponseModelFactory
{
    public static CityResponseModel GetModel()
    {
        return GetModels(1).First();
    }

    public static CityResponseModel[] GetModels(int count = 5)
    {
        return new Faker<CityResponseModel>()
            .RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Name, f => f.Address.City())
            .RuleFor(x => x.Coordinates, CoordinateResponseModelFactory.GetModel)
            .RuleFor(x => x.CountryCode, f => f.Address.CountryCode())
            .RuleFor(x => x.Population, f => f.Random.Int())
            .RuleFor(x => x.TimezoneShift, f => f.Random.Int())
            .RuleFor(x => x.SunriseTime, f => f.Random.Int())
            .RuleFor(x => x.SunsetTime, f => f.Random.Int())
            .Generate(count).ToArray();
    }
}