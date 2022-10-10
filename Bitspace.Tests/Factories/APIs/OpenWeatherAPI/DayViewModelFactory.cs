using Bitspace.APIs;
using Bogus;

namespace Bitspace.Tests.Factories.APIs.OpenWeatherAPI
{
    public static class DayViewModelFactory
    {
        public static DayViewModel GetModel()
        {
            return GetModels(1).First();
        }

        public static DayViewModel[] GetModels(int count = 5)
        {
            return new Faker<DayViewModel>()
                .CustomInstantiator(f => new DayViewModel(f.Date.Future(), ForecastItemViewModelFactory.GetModels().ToList()))
                .Generate(count).ToArray();
        }
    }
}