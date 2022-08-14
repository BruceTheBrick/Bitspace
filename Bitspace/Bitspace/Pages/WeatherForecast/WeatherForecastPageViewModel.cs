﻿using System.Threading.Tasks;
using Bitspace.APIs;
using Bitspace.Services;
using Prism.Navigation;

namespace Bitspace.Pages;

public class WeatherForecastPageViewModel : BasePageViewModel
{
    private readonly ICurrentWeatherService _currentWeatherService;
    public WeatherForecastPageViewModel(
        INavigationService navigationService,
        ICurrentWeatherService currentWeatherService)
        : base(navigationService)
    {
        _currentWeatherService = currentWeatherService;
    }

    public CurrentWeatherViewModel Weather { get; set; }

    public override async Task InitializeAsync(INavigationParameters parameters)
    {
        await base.InitializeAsync(parameters);
        await UpdateCurrentWeather();
    }

    private async Task UpdateCurrentWeather()
    {
        IsBusy = true;
        Weather = await _currentWeatherService.GetCurrentWeather();
        IsBusy = false;
    }
}