using System;
using System.Linq;
using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories
{
    public static class MainResponseModelFactory
    {
        public static MainResponseModel GetModel()
        {
            return GetModels(1).First();
        }

        public static MainResponseModel[] GetModels(int count = 5)
        {
            return new Faker<MainResponseModel>()
                .RuleFor(x => x.Humidity, f => f.Random.Int())
                .RuleFor(x => x.Pressure, f => f.Random.Int())
                .RuleFor(x => x.Temperature, f => f.Random.Double())
                .RuleFor(x => x.FeelsLike, f => f.Random.Double())
                .RuleFor(x => x.TemperatureMax, f => f.Random.Double(0, Double.MaxValue))
                .RuleFor(x => x.TemperatureMin, f => f.Random.Double(Double.MinValue, 0))
                .Generate(count).ToArray();
        }
    }
}