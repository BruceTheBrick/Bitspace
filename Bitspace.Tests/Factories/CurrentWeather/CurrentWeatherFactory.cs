namespace Bitspace.Tests.Factories;

public static class CurrentWeatherFactory
{
    public static CurrentWeatherResponse GetModel()
    {
        return GetModels(1).First();
    }
    
    public static CurrentWeatherViewModel GetViewModel()
    {
        return GetViewModels(1).First();
    }

    public static CurrentWeatherResponse[] GetModels(int count = 5)
    {
        return new Faker<CurrentWeatherResponse>()
            .RuleFor(x => x.Base, f => f.Lorem.Word())
            .RuleFor(x => x.Clouds, CloudsResponseModelFactory.GetModel())
            .RuleFor(x => x.Cod, f => f.Random.Int())
            .RuleFor(x => x.Coordinates, CoordinateResponseModelFactory.GetModel())
            .RuleFor(x => x.Id, f => f.Random.Double(double.MinValue, double.MaxValue))
            .RuleFor(x => x.Main, MainResponseModelFactory.GetModel())
            .RuleFor(x => x.System, SystemResponseModelFactory.GetModel())
            .RuleFor(x => x.Timezone, f => f.Random.Int())
            .RuleFor(x => x.Visibility, f => f.Random.Int())
            .RuleFor(x => x.Weather, WeatherResponseModelFactory.GetModels())
            .RuleFor(x => x.Wind, WindResponseModelFactory.GetModel())
            .RuleFor(x => x.DT, f => f.Random.Double(double.MinValue, double.MaxValue))
            .Generate(count).ToArray();
    }

    public static CurrentWeatherViewModel[] GetViewModels(int count = 5)
    {
        var models = GetModels(count);
        return models.Select(model => new CurrentWeatherViewModel(model)).ToArray();
    }
}