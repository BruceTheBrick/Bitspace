using System;
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

    public async Task<CurrentWeatherViewModel> GetCurrentWeather()
    {
        if (_timeoutService.IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherViewModel;
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
            var response = await _openWeatherApi.GetCurrentWeather(new CurrentWeatherRequest(location.Latitude, location.Longitude));
            if (response.IsSuccess)
            {
                _currentWeatherResponse = response.Data;
                _currentWeatherViewModel = new CurrentWeatherViewModel(_currentWeatherResponse);
                _timeoutService.Update();
            }
        }
        catch (HttpRequestException)
        {
            await _alertService.Snackbar("Uh oh, looks like we timed out! Please try again later..");
        }
        catch (Exception e)
        {
            await _alertService.Snackbar(e.Message);
        }
    }
}