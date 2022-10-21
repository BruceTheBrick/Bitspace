using System.Linq;
using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories
{
    public static class SnowResponseModelFactory
    {
        public static SnowResponseModel GetModel()
        {
            return GetModels(1).First();
        }

        public static SnowResponseModel[] GetModels(int count = 5)
        {
            return new Faker<SnowResponseModel>()
                .RuleFor(x => x.SnowVolume, f => f.Random.Double())
                .Generate(count).ToArray();
        }
    }
}