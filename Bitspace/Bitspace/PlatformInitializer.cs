using System.Diagnostics.CodeAnalysis;
using Bitspace.APIs;
using Bitspace.Controls;
using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Features.Buttons;
using Bitspace.UI;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Bitspace
{
    [ExcludeFromCodeCoverage]
    public class PlatformInitializer
    {
        public PlatformInitializer(IContainerRegistry containerRegistry)
        {
            RegisterServices(containerRegistry);
            RegisterApis(containerRegistry);
            RegisterDataLayers(containerRegistry);
            RegisterNavigation(containerRegistry);
            RegisterPlaygroundPagesForNavigation(containerRegistry);
        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IApiKeyManagerService, ApiKeyManagerService>();
            containerRegistry.RegisterSingleton<IEssentialsVersion, EssentialsVersion>();
            containerRegistry.RegisterSingleton<IEssentialsDeviceInfo, EssentialsDeviceInfo>();
            containerRegistry.Register<IBaseService, BaseService>();
            containerRegistry.Register<IHttpClient, ExtendedHttpClient>();
            containerRegistry.Register<IHomePageMenuItems, HomePageMenuItemService>();
            containerRegistry.Register<IBiometricService, BiometricService>();
            containerRegistry.Register<ITimeoutService, TimeoutService>();
            containerRegistry.Register<IPermissionService, PermissionService>();
            containerRegistry.Register<IAnimationService, AnimationService>();
            containerRegistry.Register<IAlertService, AlertService>();
            containerRegistry.Register<IAccessibilityService, AccessibilityService>();
            containerRegistry.Register<INavigationService, NavigationService>();
            containerRegistry.Register<IConnectFourEngine, ConnectFourEngine>();
            containerRegistry.Register<IConnectFourScoringService, ConnectFourScoringService>();
            containerRegistry.Register<ITimerService, TimerService>();
            containerRegistry.Register<IDeviceLocation, DeviceLocationService>();
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<InitPage, InitPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<WeatherForecastPage, WeatherForecastPageViewModel>();
            containerRegistry.RegisterForNavigation<ConnectFourPage, ConnectFourPageViewModel>();
            containerRegistry.RegisterForNavigation<SnackbarPopup, SnackbarPopupViewModel>();
            containerRegistry.RegisterForNavigation<GameOverPopupPage, GameOverPopupPageViewModel>();
        }

        private void RegisterPlaygroundPagesForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PlaygroundPage, PlaygroundPageViewModel>();
            containerRegistry.RegisterForNavigation<AccessibilityPlaygroundPage, AccessibilityPlaygroundPageViewModel>();
            containerRegistry.RegisterForNavigation<ButtonsPlaygroundPage, ButtonsPlaygroundPageViewModel>();
        }

        private void RegisterApis(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IOpenWeatherAPI, OpenWeatherAPI>();
        }

        private void RegisterDataLayers(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICurrentWeatherService, WeatherService>();
        }
    }
}