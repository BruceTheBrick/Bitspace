using Bitspace.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Bitspace.Droid.Services.DeviceLocation
{
    public class DeviceLocationService : IDeviceLocation
    {
        public async Task<LocationModel> GetCurrentLocation(LocationAccuracy accuracy, int timeout = 5)
        {
            try
            {
                var request = new GeolocationRequest(LocationAccuracyToGeolocationAccuray(accuracy),
                    TimeSpan.FromSeconds(timeout));
                var location = await Geolocation.GetLocationAsync(request);
                return new LocationModel
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        private GeolocationAccuracy LocationAccuracyToGeolocationAccuray(LocationAccuracy accuracy)
        {
            switch (accuracy)
            {
                case LocationAccuracy.High:
                    return GeolocationAccuracy.High;
                case LocationAccuracy.Medium:
                    return GeolocationAccuracy.Medium;
                case LocationAccuracy.Low:
                default:
                    return GeolocationAccuracy.Low;

            }
        }
    }
}