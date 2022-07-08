using Bitspace.APIs.OpenWeather.Models;
using Bogus;

namespace Bitspace.Tests.Factories.CurrentWeatherServiceFactories;

public static class CurrentWeatherViewModelFactory
{
    public static CurrentWeatherViewModel GetViewModel()
    {
        return GetViewModels(1).First();
    }

    public static CurrentWeatherViewModel[] GetViewModels(int count = 5)
    {
        return new Faker<CurrentWeatherViewModel>()
            .RuleFor(x => x.Suburb, f => f.Person.FirstName)
            .RuleFor(x => x.Temperature, f => f.Random.Double(-180, 180))
            .RuleFor(x => x.Humidity, f => f.Random.Double(-180, 180))
            .RuleFor(x => x.WindSpeed, f => f.Random.Double(-180, 180))
            .RuleFor(x => x.Pressure, f => f.Random.Double(-180, 180))
            .Generate(count).ToArray();

    }
}