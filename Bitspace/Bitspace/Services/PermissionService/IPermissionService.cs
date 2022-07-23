using System.Threading.Tasks;

namespace Bitspace.Services.PermissionService;

public interface IPermissionService
{
    public Task<bool> RequestPermission(DevicePermissions permission);
}