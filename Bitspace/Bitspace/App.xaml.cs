using Bitspace.APIs;
using Bitspace.APIs.OpenWeather;
using Bitspace.APIs.OpenWeather.Data_Layers;
using Bitspace.Constants;
using Bitspace.Pages.Mainpage;
using Bitspace.Pages.Mainpage.Services.MainpageMenuItems;
using Bitspace.Pages.WeatherForecast;
using Bitspace.Services.CachingService;
using Bitspace.Services.DeviceInformation;
using Bitspace.Services.FirebaseRemoteConfig;
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
            await NavigationService.NavigateAsync($"NavigationPage/{NavigationConstants.Mainpage}");
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
            containerRegistry.Register<IFirebaseRemoteConfig, FirebaseRemoteConfigService>();
            containerRegistry.Register<IHttpClient, ExtendedHttpClient>();
            containerRegistry.Register<IMainpageMenuItems, MainpageMenuItemService>();
            containerRegistry.RegisterSingleton<ICachingService, CachingService>();
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(NavigationConstants.Mainpage);
            containerRegistry.RegisterForNavigation<WeatherForecastPage, WeatherForecastPageViewModel>(NavigationConstants.WeatherForecast);
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
