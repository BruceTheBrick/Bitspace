using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories
{
    public static class HourlyWeatherResponseFactory
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
                .RuleFor(x => x.List, f => ForecastListObjectResponseFactory.GetModels())
                .RuleFor(x => x.City, f => CityResponseModelFactory.GetModel())
                .Generate(count).ToArray();
        }
    }
}