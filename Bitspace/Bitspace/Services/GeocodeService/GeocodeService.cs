using System;
using System.Net.Http;
using System.Threading.Tasks;
using Bitspace.APIs;

namespace Bitspace.Services
{
    public class GeocodeService : IGeocodeService
    {
        private readonly IOpenWeatherAPI _openWeatherApi;
        private readonly ITimeoutService _timeoutService;
        private readonly IPermissionService _permissionService;
        private readonly IAlertService _alertService;
        private readonly IDeviceLocation _deviceLocationService;

        private ReverseGeocodeResponseItemModel[] _currentLocationResponseModel;
        private ReverseGeocodeViewModel _currentLocationViewModel;
        private DateTime _currentLocationLastUpdate;

        public GeocodeService(
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

        public async Task<ReverseGeocodeViewModel> GetCurrentLocationName()
        {
            if (_timeoutService.IsExpired(_currentLocationLastUpdate))
            {
                await FetchCurrentLocationName();
            }

            return _currentLocationViewModel;
        }

        private async Task FetchCurrentLocationName()
        {
            try
            {
                if (!await _permissionService.RequestPermission(DevicePermissions.LOCATION))
                {
                    return;
                }

                var location = await _deviceLocationService.GetCurrentLocation(LocationAccuracy.High);
                var response = await _openWeatherApi.GetCurrentLocationName(new ReverseGeocodeRequest(location));
                if (response.IsSuccess)
                {
                    _currentLocationResponseModel = response.Data;
                    _currentLocationViewModel = new ReverseGeocodeViewModel(_currentLocationResponseModel);
                    _currentLocationLastUpdate = DateTime.Now;
                }
            }
            catch (HttpRequestException)
            {
                await _alertService.Snackbar("Uh oh, looks like we timed out! Please try again later..");
                InitCurrentLocationItems();
            }
            catch (Exception e)
            {
                await _alertService.Snackbar(e.Message);
                InitCurrentLocationItems();
            }
        }

        private void InitCurrentLocationItems()
        {
            _currentLocationResponseModel = Array.Empty<ReverseGeocodeResponseItemModel>();
            _currentLocationViewModel = new ReverseGeocodeViewModel();
        }
    }
}