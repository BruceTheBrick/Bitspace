using Bitspace.APIs;
using Bitspace.APIs.OpenWeather;
using Bitspace.Constants;
using Bitspace.Pages;
using Bitspace.Pages.Mainpage;
using Bitspace.Pages.Mainpage.Services.MainpageMenuItems;
using Bitspace.Pages.QRCodeScanner;
using Bitspace.Pages.WeatherForecast;
using Bitspace.Services.AlertService;
using Bitspace.Services.AnimationService;
using Bitspace.Services.APIKeyManager;
using Bitspace.Services.BiometricService;
using Bitspace.Services.CachingService;
using Bitspace.Services.CurrentWeatherService;
using Bitspace.Services.DeviceInformation;
using Bitspace.Services.PermissionService;
using Bitspace.Services.TimeoutService;
using DLToolkit.Forms.Controls;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Bitspace
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            FlowListView.Init();
            Sharpnado.MaterialFrame.Initializer.Initialize(false, true);
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
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
            containerRegistry.RegisterSingleton<IDeviceInformationService, DeviceInformationService>();
            containerRegistry.Register<IHttpClient, ExtendedHttpClient>();
            containerRegistry.Register<IMainpageMenuItems, MainpageMenuItemService>();
            containerRegistry.RegisterSingleton<ICachingService, CachingService>();
            containerRegistry.Register<IBiometricService, BiometricService>();
            containerRegistry.Register<ITimeoutService, TimeoutService>();
            containerRegistry.RegisterSingleton<IApiKeyManagerService, ApiKeyManagerService>();
            containerRegistry.Register<IPermissionService, PermissionService>();
            containerRegistry.Register<IAnimationService, AnimationService>();
            containerRegistry.Register<IAlertService, AlertService>();
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(nameof(NavigationPage));
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(nameof(MainPage));
            containerRegistry.RegisterForNavigation<WeatherForecastPage, WeatherForecastPageViewModel>(nameof(WeatherForecastPage));
            containerRegistry.RegisterForNavigation<QRCodeScannerPage, QRCodeScannerPageViewModel>(nameof(QRCodeScannerPage));
        }

        private void RegisterAPIs(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IOpenWeatherAPI, OpenWeatherAPI>();
        }

        private void RegisterDataLayers(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICurrentWeatherService, CurrentWeatherService>();
        }
    }
}
