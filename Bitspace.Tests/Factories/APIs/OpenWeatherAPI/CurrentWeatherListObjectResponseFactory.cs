namespace Bitspace.Tests.Factories;

public static class CurrentWeatherListObjectResponseFactory
{
    public static CurrentWeatherListObjectResponse GetModel()
    {
        return GetModels(1).First();
    }

    public static CurrentWeatherListObjectResponse[] GetModels(int count = 5)
    {
        return new Faker<CurrentWeatherListObjectResponse>()
            .RuleFor(x => x.DT, f => f.Random.Int())
            .RuleFor(x => x.Main, MainResponseModelFactory.GetModel())
            .RuleFor(x => x.Weather, WeatherResponseModelFactory.GetModels())
            .RuleFor(x => x.Clouds, CloudsResponseModelFactory.GetModel())
            .RuleFor(x => x.Wind, WindResponseModelFactory.GetModel())
            .RuleFor(x => x.Visibility, f => f.Random.Int())
            .RuleFor(x => x.RainChance, f => f.Random.Double())
            .RuleFor(x => x.Rain, RainResponseModelFactory.GetModel())
            .RuleFor(x => x.Snow, SnowResponseModelFactory.GetModel())
            .RuleFor(x => x.System, SystemResponseModelFactory.GetModel())
            .RuleFor(x => x.DateTimeText, f => f.Date.Soon().ToLongDateString())
            .Generate(count).ToArray();
    }
}