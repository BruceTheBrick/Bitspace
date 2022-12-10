using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Bitspace.Core
{
    public interface IDeviceLocation
    {
        Task<Location> GetCurrentLocation(GeolocationAccuracy accuracy, int timeout = 5);
    }
}
