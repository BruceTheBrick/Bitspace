using System.Linq;
using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories
{
    public static class SystemResponseModelFactory
    {
        public static SystemResponseModel GetModel()
        {
            return GetModels(1).First();
        }

        public static SystemResponseModel[] GetModels(int count = 5)
        {
            return new Faker<SystemResponseModel>()
                .RuleFor(x => x.Country, f => f.Address.Country())
                .RuleFor(x => x.Id, f => f.Random.Int())
                .RuleFor(x => x.Sunrise, f => f.Random.Double(double.MinValue, double.MaxValue))
                .RuleFor(x => x.Sunset, f => f.Random.Double(double.MinValue, double.MaxValue))
                .RuleFor(x => x.Type, f => f.Random.Int())
                .Generate(count).ToArray();
        }
    }
}