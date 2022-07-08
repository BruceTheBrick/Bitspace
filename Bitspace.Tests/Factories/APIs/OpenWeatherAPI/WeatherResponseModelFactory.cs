using Bitspace.APIs.OpenWeather.Response_Models;
using Bogus;

namespace Bitspace.Tests.Factories.APIs.OpenWeatherAPI;

public static class WeatherResponseModelFactory
{
    public static WeatherResponseModel GetModel()
    {
        return GetModels(1).First();
    }

    public static WeatherResponseModel[] GetModels(int count = 5)
    {
        return new Faker<WeatherResponseModel>()
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.Icon, f => f.Image.PicsumUrl())
            .RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Main, f => f.Lorem.Word())
            .Generate(count).ToArray();
    }
}