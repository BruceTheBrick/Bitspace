using System.Linq;
using Bitspace.Controls;
using Bitspace.UI;
using Bogus;

namespace Bitspace.Tests.Factories
{
    public static class PillViewModelFactory
    {
        public static PillViewModel GetModel()
        {
            return GetModels(1).First();
        }

        public static PillViewModel[] GetModels(int count = 5)
        {
            return new Faker<PillViewModel>()
                .CustomInstantiator(f => new PillViewModel(
                    f.Company.CompanyName(),
                    f.Image.PicsumUrl(),
                    f.Random.Bool(),
                    f.Random.Bool(),
                    f.Random.Uuid().ToString()))
                .Generate(count).ToArray();
        }
    }
}