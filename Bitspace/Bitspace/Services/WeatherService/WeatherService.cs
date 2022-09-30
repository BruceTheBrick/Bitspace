using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.APIs;

namespace Bitspace.Services;

public class CurrentWeatherService : ICurrentWeatherService
{
    private readonly IOpenWeatherAPI _openWeatherApi;
    private readonly ITimeoutService _timeoutService;
    private readonly IPermissionService _permissionService;
    private readonly IAlertService _alertService;
    private readonly IDeviceLocation _deviceLocationService;

    private CurrentWeatherResponse _currentWeatherResponse;
    private CurrentWeatherViewModel _currentWeatherViewModel;
    private HourlyWeatherResponse _hourlyForecastResponse;
    private HourlyForecastViewModel _hourlyForecastViewModel;
    private DateTime _currentWeatherLastUpdate;
    private DateTime _hourlyForecastLastUpdate;

    public CurrentWeatherService(
        IOpenWeatherAPI openWeatherApi,
        ITimeoutService timeoutService,
        IPermissionService permissionService,
        IDeviceLocation deviceLocationService,
        IAlertService alertService)
    {
        _openWeatherApi = openWeatherApi;
        _timeoutService = timeoutService;
        _permissionService = permissionService;
        _deviceLocationService = deviceLocationService;
        _alertService = alertService;

        _timeoutService.ExpiryMinutes = 5;
    }

    public async Task<string> GetLocationName()
    {
        if (!await _permissionService.RequestPermission(DevicePermissions.LOCATION))
        {
            return string.Empty;
        }

        var location = await _deviceLocationService.GetCurrentLocation(LocationAccuracy.High);
        var response = await _openWeatherApi.GetCurrentLocationName(new ReverseGeocodeRequest(location));
        return response.Data.Items.First().Name;
    }

    public async Task<CurrentWeatherViewModel> GetCurrentWeather()
    {
        if (_timeoutService.IsExpired(_currentWeatherLastUpdate))
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherViewModel;
    }

    public async Task<HourlyForecastViewModel> GetHourlyForecast()
    {
        if (_timeoutService.IsExpired(_hourlyForecastLastUpdate))
        {
            await FetchHourlyForecast();
        }

        return _hourlyForecastViewModel;
    }

    private async Task FetchHourlyForecast()
    {
        try
        {
            if (!await _permissionService.RequestPermission(DevicePermissions.LOCATION))
            {
                return;
            }

            var location = await _deviceLocationService.GetCurrentLocation(LocationAccuracy.High);
            var response = await _openWeatherApi.GetHourlyWeather(new HourlyForecastRequest(location));
            if (response.IsSuccess)
            {
                _hourlyForecastResponse = response.Data;
                _hourlyForecastViewModel = new HourlyForecastViewModel(_hourlyForecastResponse);
                _hourlyForecastLastUpdate = DateTime.Now;
            }
        }
        catch (HttpRequestException)
        {
            await _alertService.Snackbar("Uh oh, looks like we timed out! Please try again later..");
            InitForecastItems();
        }
        catch (Exception e)
        {
            await _alertService.Snackbar(e.Message);
            InitForecastItems();
        }
    }

    private async Task FetchCurrentWeather()
    {
        try
        {
            if (!await _permissionService.RequestPermission(DevicePermissions.LOCATION))
            {
                return;
            }

            var location = await _deviceLocationService.GetCurrentLocation(LocationAccuracy.High);
            var response = await _openWeatherApi.GetCurrentWeather(new CurrentWeatherRequest(location));
            if (response.IsSuccess)
            {
                _currentWeatherResponse = response.Data;
                _currentWeatherViewModel = new CurrentWeatherViewModel(_currentWeatherResponse);
                _currentWeatherLastUpdate = DateTime.Now;
            }
        }
        catch (HttpRequestException)
        {
            await _alertService.Snackbar("Uh oh, looks like we timed out! Please try again later..");
            InitCurrentWeatherItems();
        }
        catch (Exception e)
        {
            await _alertService.Snackbar(e.Message);
            InitCurrentWeatherItems();
        }
    }

    private void InitForecastItems()
    {
        _hourlyForecastResponse = new HourlyWeatherResponse();
        _hourlyForecastViewModel = new HourlyForecastViewModel();
    }

    private void InitCurrentWeatherItems()
    {
        _currentWeatherResponse = new CurrentWeatherResponse();
        _currentWeatherViewModel = new CurrentWeatherViewModel();
    }
}