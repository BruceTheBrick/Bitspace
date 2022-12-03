using System.Diagnostics.CodeAnalysis;
using Bitspace.iOS.Services;
using Bitspace.Services;
using Prism;
using Prism.Ioc;

namespace Bitspace.iOS
{
    [ExcludeFromCodeCoverage]
    public class PlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterServices(containerRegistry);
            InitHelpers();
        }

        private void RegisterServices(IContainerRegistry containerRegister)
        {
            containerRegister.Register<IFirebaseAnalyticsService, FirebaseAnalyticsService>();
            containerRegister.Register<IRemoteConfigService, RemoteConfigService>();
        }

        private void InitHelpers()
        {
            Bitspace.Helpers.Accessibility.Current = new Helpers.AccessibilityImplementation();
        }
    }
}