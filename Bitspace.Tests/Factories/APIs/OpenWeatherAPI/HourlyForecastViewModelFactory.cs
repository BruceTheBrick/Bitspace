using System.Linq;
using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories;

public static class HourlyForecastViewModelFactory
{
    public static HourlyForecastViewModel GetModel()
    {
        return GetModels(1).First();
    }

    public static HourlyForecastViewModel[] GetModels(int count = 5)
    {
        return new Faker<HourlyForecastViewModel>()
            .CustomInstantiator(f => new HourlyForecastViewModel(HourlyWeatherResponseFactory.GetModel()))
            .Generate(count).ToArray();
    }
}