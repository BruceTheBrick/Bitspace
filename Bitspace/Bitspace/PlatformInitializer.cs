using System.Diagnostics.CodeAnalysis;
using Bitspace.APIs;
using Bitspace.Controls;
using Bitspace.Features;
using Bitspace.Services;
using Bitspace.Services.TimerService;
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
            RegisterAPIs(containerRegistry);
            RegisterDataLayers(containerRegistry);
            RegisterNavigation(containerRegistry);
        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.Register<IBaseService, BaseService>();
            containerRegistry.Register<IHttpClient, ExtendedHttpClient>();
            containerRegistry.Register<IHomePageMenuItems, HomePageMenuItemService>();
            containerRegistry.Register<IBiometricService, BiometricService>();
            containerRegistry.Register<ITimeoutService, TimeoutService>();
            containerRegistry.RegisterSingleton<IApiKeyManagerService, ApiKeyManagerService>();
            containerRegistry.Register<IPermissionService, PermissionService>();
            containerRegistry.Register<IAnimationService, AnimationService>();
            containerRegistry.Register<IAlertService, AlertService>();
            containerRegistry.Register<IAccessibilityService, AccessibilityService>();
            containerRegistry.Register<INavigationService, NavigationService>();
            containerRegistry.RegisterSingleton<IEssentialsVersion, EssentialsVersion>();
            containerRegistry.Register<IBoard, Board>();
            containerRegistry.Register<ITimerService, TimerService>();
            containerRegistry.Register<IDeviceLocation, DeviceLocationService>();
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<WeatherForecastPage, WeatherForecastPageViewModel>();
            containerRegistry.RegisterForNavigation<QRCodeScannerPage, QRCodeScannerPageViewModel>();
            containerRegistry.RegisterForNavigation<ConnectFourPage, ConnectFourPageViewModel>();
            containerRegistry.RegisterForNavigation<SnackbarPopup, SnackbarPopupViewModel>();
            containerRegistry.RegisterForNavigation<GameOverPopupPage, GameOverPopupPageViewModel>();
        }

        private void RegisterAPIs(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IOpenWeatherAPI, OpenWeatherAPI>();
        }

        private void RegisterDataLayers(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICurrentWeatherService, WeatherService>();
        }
    }
}