using System.Threading.Tasks;

namespace Bitspace.Services
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
