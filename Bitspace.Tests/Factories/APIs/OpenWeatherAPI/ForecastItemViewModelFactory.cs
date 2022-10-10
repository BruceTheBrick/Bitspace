using Bitspace.APIs;

namespace Bitspace.Tests.Factories
{
    public static class ForecastItemViewModelFactory
    {
        public static ForecastItemViewModel GetModel()
        {
            return GetModels(1).First();
        }

        public static ForecastItemViewModel[] GetModels(int count = 5)
        {
            var models = new List<ForecastItemViewModel>();
            for (var i = 0; i < count; i++)
            {
                models.Add(new ForecastItemViewModel(ForecastListObjectResponseFactory.GetModel()));
            }

            return models.ToArray();
        }
    }
}