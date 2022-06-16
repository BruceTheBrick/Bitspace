using System.Threading.Tasks;
using Bitspace.Services.DeviceLocation.Models;

namespace Bitspace.Services.DeviceLocation
{
    public enum LocationAccuracy
    {
        High,
        Medium,
        Low,
    }

    public interface IDeviceLocation
    {
        Task<LocationModel> GetCurrentLocation(LocationAccuracy accuracy, int timeout = 5);
    }
}
