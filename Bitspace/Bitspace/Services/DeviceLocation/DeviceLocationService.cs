using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Bitspace.Services
{
    public class DeviceLocationService : IDeviceLocation
    {
        public async Task<Location> GetCurrentLocation(GeolocationAccuracy accuracy, int timeout = 5)
        {
            var request = new GeolocationRequest(accuracy, TimeSpan.FromSeconds(timeout));
            return await Geolocation.GetLocationAsync(request);
        }
    }
}