using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Data_Layers;
using Bitspace.APIs.OpenWeather.Models;
using Prism.Navigation;

namespace Bitspace.Pages.WeatherForecast;

public class WeatherForecastPageViewModel : BasePageViewModel
{
    private readonly ICurrentWeatherService _currentWeatherService;
    public WeatherForecastPageViewModel(
        INavigationService navigationService,
        ICurrentWeatherService currentWeatherService)
        : base(navigationService)
    {
        _currentWeatherService = currentWeatherService;
        Title = "Main Page";
    }

    public CurrentWeatherViewModel Weather { get; set; }

    public override async Task InitializeAsync(INavigationParameters parameters)
    {
        await base.InitializeAsync(parameters);
        Task.Run(UpdateCurrentWeather);
    }

    private async Task UpdateCurrentWeather()
    {
        IsBusy = true;
        Weather = await _currentWeatherService.GetCurrentWeather();
        IsBusy = false;
    }
}