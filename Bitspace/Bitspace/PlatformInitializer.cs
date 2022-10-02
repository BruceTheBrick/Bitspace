﻿using System.Diagnostics.CodeAnalysis;
using Bitspace.APIs;
using Bitspace.Pages;
using Bitspace.Services;
using Bitspace.Services.GeocodeService;
using Bitspace.Services.NavigationService;
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
            containerRegistry.RegisterSingleton<IDeviceInformationService, DeviceInformationService>();
            containerRegistry.Register<IHttpClient, ExtendedHttpClient>();
            containerRegistry.Register<IHomePageMenuItems, HomePageMenuItemService>();
            containerRegistry.RegisterSingleton<ICachingService, CachingService>();
            containerRegistry.Register<IBiometricService, BiometricService>();
            containerRegistry.Register<ITimeoutService, TimeoutService>();
            containerRegistry.RegisterSingleton<IApiKeyManagerService, ApiKeyManagerService>();
            containerRegistry.Register<IPermissionService, PermissionService>();
            containerRegistry.Register<IAnimationService, AnimationService>();
            containerRegistry.Register<IAlertService, AlertService>();
            containerRegistry.Register<IAccessibilityService, AccessibilityService>();
            containerRegistry.Register<INavigationService, NavigationService>();
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<WeatherForecastPage, WeatherForecastPageViewModel>();
            containerRegistry.RegisterForNavigation<QRCodeScannerPage, QRCodeScannerPageViewModel>();
        }

        private void RegisterAPIs(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IOpenWeatherAPI, OpenWeatherAPI>();
        }

        private void RegisterDataLayers(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICurrentWeatherService, CurrentWeatherService>();
            containerRegistry.RegisterSingleton<IGeocodeService, GeocodeService>();
        }
    }
}