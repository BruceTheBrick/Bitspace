using Bitspace.Core;
using Bitspace.Droid.Services;
using Prism;
using Prism.Ioc;

namespace Bitspace.Droid
{
    public class PlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            RegisterServices(containerRegistry);
        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRemoteConfigService, RemoteConfigService>();
            containerRegistry.Register<IFirebaseAnalyticsService, FirebaseAnalyticsService>();
        }
    }
}