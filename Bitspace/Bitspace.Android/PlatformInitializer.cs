using Bitspace.Droid.Services.DeviceLocation;
using Bitspace.Droid.Services.RemoteConfigService;
using Bitspace.Services;
using Prism;
using Prism.Ioc;

namespace Bitspace.Droid;

public class PlatformInitializer : IPlatformInitializer
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Register any platform specific implementations
        RegisterServices(containerRegistry);
    }

    private void RegisterServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IDeviceLocation, DeviceLocationService>();
        containerRegistry.RegisterSingleton<IRemoteConfigService, RemoteConfigService>();
    }
}