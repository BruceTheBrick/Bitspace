using System.Threading.Tasks;

namespace Bitspace.Services
{
    public interface IPermissionService
    {
        public Task<bool> RequestPermission(DevicePermissions permission);
    }
}