using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather;
using Bitspace.APIs.OpenWeather.Models;
using Bitspace.APIs.OpenWeather.Response_Models;
using Bitspace.Services.AlertService;
using Bitspace.Services.PermissionService;
using Bitspace.Services.TimeoutService;

namespace Bitspace.Services.CurrentWeatherService;

public class CurrentWeatherService : ICurrentWeatherService
{
    private readonly IOpenWeatherAPI _openWeatherApi;
    private readonly ITimeoutService _timeoutService;
    private readonly IPermissionService _permissionService;
    private readonly IAlertService _alertService;

    private CurrentWeatherResponse _currentWeatherResponse;
    private CurrentWeatherViewModel _currentWeatherViewModel;

    public CurrentWeatherService(
        IOpenWeatherAPI openWeatherApi,
        ITimeoutService timeoutService,
        IPermissionService permissionService,
        IAlertService alertService)
    {
        _openWeatherApi = openWeatherApi;
        _timeoutService = timeoutService;
        _permissionService = permissionService;
        _alertService = alertService;

        _timeoutService.ExpiryMinutes = 5;
    }

    public async Task<CurrentWeatherViewModel> GetCurrentWeather()
    {
        if (!await _permissionService.RequestPermission(DevicePermissions.LOCATION))
        {
            return null;
        }

        if (_timeoutService.IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherViewModel;
    }

    public async Task<string> GetSuburb()
    {
        if (_timeoutService.IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherResponse.Name;
    }

    public async Task<double> GetTemperature()
    {
        if (_timeoutService.IsExpired())
        {
            await FetchCurrentWeather();
        }

        return Math.Round(_currentWeatherResponse.Main.Temperature, 2);
    }

    public async Task<double> GetHumidity()
    {
        if (_timeoutService.IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherResponse.Main.Humidity;
    }

    public async Task<double> GetWindSpeed()
    {
        if (_timeoutService.IsExpired())
        {
            await FetchCurrentWeather();
        }

        return Math.Round(_currentWeatherResponse.Wind.Speed, 2);
    }

    public async Task<double> GetPressure()
    {
        if (_timeoutService.IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherResponse.Main.Pressure;
    }

    private async Task FetchCurrentWeather()
    {
        try
        {
            var response = await _openWeatherApi.GetCurrentWeather();
            if (response.IsSuccess)
            {
                _currentWeatherResponse = response.Data;
                InitCurrentWeatherViewModel();
                _timeoutService.Update();
            }
        }
        catch (HttpRequestException requestException)
        {
            await _alertService.Snackbar("Uh oh, something went wrong! Please try again later.");
        }
    }

    private void InitCurrentWeatherViewModel()
    {
        _currentWeatherViewModel = new CurrentWeatherViewModel
        {
            Suburb = _currentWeatherResponse.Name,
            Temperature = _currentWeatherResponse.Main.Temperature,
            Humidity = _currentWeatherResponse.Main.Humidity,
            Pressure = _currentWeatherResponse.Main.Pressure,
            WindSpeed = _currentWeatherResponse.Wind.Speed,
            Description = _currentWeatherResponse.Weather?[0].Description,
            DescriptionList = GetDescriptionsFromResponse(),
        };
    }

    private List<string> GetDescriptionsFromResponse()
    {
        return _currentWeatherResponse.Weather.Select(weather => weather.Description.ToUpper()).ToList();
    }
}