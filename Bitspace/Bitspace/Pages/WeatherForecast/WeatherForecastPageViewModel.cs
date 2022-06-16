using Bitspace.APIs.OpenWeather;
using Bitspace.APIs.OpenWeather.Responses;
using Bitspace.Services.FirebaseAnalytics;
using Prism.Navigation;

namespace Bitspace.Pages.WeatherForecast
{
    public class WeatherForecastPageViewModel : BasePageViewModel
    {
        private readonly IFirebaseAnalyticsService _firebaseAnalyticsService;
        private readonly IOpenWeatherService _openWeatherService;
        public WeatherForecastPageViewModel(
            INavigationService navigationService,
            IOpenWeatherService openWeatherService,
            IFirebaseAnalyticsService firebaseAnalyticsService)
            : base(navigationService)
        {
            _openWeatherService = openWeatherService;
            _firebaseAnalyticsService = firebaseAnalyticsService;
            Title = "Main Page";
        }

        public double Temperature { get; set; }
        public CurrentWeatherResponse Weather { get; set; }

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            IsBusy = true;
            var weather = await _openWeatherService.GetCurrentWeather();
            Weather = weather;
            Temperature = weather.Main.Temperature;
            _firebaseAnalyticsService.LogEvent("Check out my event!");
            IsBusy = false;
        }
    }
}
