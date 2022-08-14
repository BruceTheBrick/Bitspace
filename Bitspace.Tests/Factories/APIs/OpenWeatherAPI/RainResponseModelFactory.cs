using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories.APIs.OpenWeatherAPI;

public static class RainResponseModelFactory
{
    public static RainResponseModel GetModel()
    {
        return GetModels(1).First();
    }

    public static RainResponseModel[] GetModels(int count = 5)
    {
        return new Faker<RainResponseModel>()
            .RuleFor(x => x.RainVolume, f => f.Random.Double())
            .Generate(count).ToArray();
    }
}