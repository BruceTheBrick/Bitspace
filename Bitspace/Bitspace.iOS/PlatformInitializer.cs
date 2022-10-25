using Bitspace.iOS.Services;
using Bitspace.Services;
using Prism;
using Prism.Ioc;

namespace Bitspace.iOS
{
    public class PlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterServices(containerRegistry);
        }

        private void RegisterServices(IContainerRegistry containerRegister)
        {
            containerRegister.Register<IFirebaseAnalyticsService, FirebaseAnalyticsService>();
            containerRegister.Register<IRemoteConfigService, RemoteConfigService>();
        }
    }
}