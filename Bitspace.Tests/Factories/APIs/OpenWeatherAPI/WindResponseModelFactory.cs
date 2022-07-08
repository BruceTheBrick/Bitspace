using Bitspace.APIs.OpenWeather.Response_Models;
using Bogus;
using Xamarin.Forms.Xaml;

namespace Bitspace.Tests.Factories.APIs.OpenWeatherAPI;

public static class WindResponseModelFactory
{
    public static WindResponseModel GetModel()
    {
        return GetModels(1).First();
    }

    public static WindResponseModel[] GetModels(int count = 5)
    {
        return new Faker<WindResponseModel>()
            .RuleFor(x => x.Degrees, f => f.Random.Int())
            .RuleFor(x => x.Gust, f => f.Random.Double(Double.MinValue, Double.MaxValue))
            .RuleFor(x => x.Speed, f => f.Random.Double(Double.MinValue, Double.MaxValue))
            .Generate(count).ToArray();
    }
}