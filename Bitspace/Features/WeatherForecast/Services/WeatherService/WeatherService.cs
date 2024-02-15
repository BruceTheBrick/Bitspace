using Bitspace.APIs;
using Bitspace.Core;

namespace Bitspace.Features;

public class WeatherService : ICurrentWeatherService
{
    private readonly IOpenWeatherAPI _openWeatherApi;
    private readonly ITimeoutService _timeoutService;
    private readonly IPermissionService _permissionService;
    private readonly IDeviceLocation _deviceLocationService;
    private readonly IAlertService _alertService;
    private HourlyWeatherResponse _hourlyForecastResponse;
    private HourlyForecastViewModel _hourlyForecastViewModel;
    private ReverseGeocodeResponseItemModel[] _locationResponseModel;
    private LocationViewModel _locationViewModel;
    private DateTime _locationLastUpdate;
    private DateTime _hourlyForecastLastUpdate;

    public WeatherService(
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

    public async Task<HourlyForecastViewModel> GetHourlyForecast()
    {
        if (_timeoutService.IsExpired(_hourlyForecastLastUpdate))
        {
            await FetchWeatherAndLocation();
        }

        return _hourlyForecastViewModel;
    }

    private async Task FetchWeatherAndLocation()
    {
        try
        {
            if (!await _permissionService.RequestPermission(DevicePermissions.LOCATION))
            {
                return;
            }

            var currentLocation = await _deviceLocationService.GetCurrentLocation(GeolocationAccuracy.Best);
            var forecastTask = FetchAndUpdateForecastItems(currentLocation);
            var locationTask = FetchAndUpdateLocationItems(currentLocation);
            await Task.WhenAll(forecastTask, locationTask);
            _hourlyForecastViewModel.Location = _locationViewModel;
        }
        catch (HttpRequestException)
        {
            await _alertService.ShowSnackbar("Uh oh, looks like we timed out! Please try again later..");
            InitForecastItems();
        }
        catch (Exception e)
        {
            await _alertService.ShowSnackbar(e.Message);
            InitForecastItems();
        }
    }

    private async Task FetchAndUpdateForecastItems(Location location)
    {
        if (!_timeoutService.IsExpired(_hourlyForecastLastUpdate))
        {
            return;
        }

        var response = await _openWeatherApi.GetHourlyWeather(new HourlyForecastRequest(location));
        if (!response.IsSuccess)
        {
            InitForecastItems();
            return;
        }

        _hourlyForecastResponse = response.Data;
        _hourlyForecastViewModel = new HourlyForecastViewModel(_hourlyForecastResponse);
        _hourlyForecastLastUpdate = DateTime.Now;
    }

    private async Task FetchAndUpdateLocationItems(Location location)
    {
        if (!_timeoutService.IsExpired(_locationLastUpdate))
        {
            return;
        }

        var response = await _openWeatherApi.GetCurrentLocationName(new ReverseGeocodeRequest(location));
        if (!response.IsSuccess)
        {
            InitLocationItems();
            return;
        }

        _locationResponseModel = response.Data;
        _locationViewModel = new LocationViewModel(_locationResponseModel.First());
        _locationLastUpdate = DateTime.Now;
    }

    private void InitForecastItems()
    {
        _hourlyForecastResponse = new HourlyWeatherResponse();
        _hourlyForecastViewModel = new HourlyForecastViewModel();
    }

    private void InitLocationItems()
    {
        _locationResponseModel = Array.Empty<ReverseGeocodeResponseItemModel>();
        _locationViewModel = new LocationViewModel();
    }
}