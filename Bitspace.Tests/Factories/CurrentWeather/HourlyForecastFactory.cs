using Bitspace.APIs;
using Bitspace.Tests.Factories.APIs.OpenWeatherAPI;
using Bogus;

namespace Bitspace.Tests.Factories;

public static class HourlyForecastFactory
{
    public static HourlyWeatherResponse GetModel()
    {
        return GetModels(1).First();
    }

    public static HourlyWeatherResponse[] GetModels(int count = 5)
    {
        return new Faker<HourlyWeatherResponse>()
            .RuleFor(x => x.Cod, f => f.Random.Int())
            .RuleFor(x => x.Message, f => f.Random.Double())
            .RuleFor(x => x.Cnt, f => f.Random.Int())
            .RuleFor(x => x.List, f => ForecastListObjectResponseFactory.GetModels(f.Random.Int(5, 10)))
            .RuleFor(x => x.City, CityResponseModelFactory.GetModel())
            .Generate(count).ToArray();
    }

    public static HourlyForecastViewModel GetViewModel()
    {
        return GetViewModels(1).First();
    }

    public static HourlyForecastViewModel[] GetViewModels(int count = 5)
    {
        var models = GetModels(count);
        var viewModels = new List<HourlyForecastViewModel>();
        foreach (var model in models)
        {
            viewModels.Add(new HourlyForecastViewModel(model));
        }

        return viewModels.ToArray();
    }
}