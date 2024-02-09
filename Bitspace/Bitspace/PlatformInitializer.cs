using System.Diagnostics.CodeAnalysis;
using Bitspace.APIs;
using Bitspace.Controls;
using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Features.Buttons;
using Bitspace.UI;
using CommunityToolkit.Maui;

namespace Bitspace;

[ExcludeFromCodeCoverage]
public static class PlatformInitializer
{
    public static MauiAppBuilder Initialize(this MauiAppBuilder builder)
    {
        builder.UsePrism(prismBuilder =>
        {
            prismBuilder.OnAppStart(async (_, nav) =>
            {
                var t = await nav.NavigateAsync(NavigationConstants.Homepage);
            });
        });
        RegisterServices(builder.Services);
        RegisterApis(builder.Services);
        RegisterDataLayers(builder.Services);
        RegisterNavigation(builder.Services);
        RegisterPlaygroundPagesForNavigation(builder.Services);
        return builder;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        RegisterAndroidServices(services);
        RegisterIosServices(services);
        // services.AddSingleton<IAppInfo, AppInfo>();
        services.AddSingleton<IApiKeyManagerService, ApiKeyManagerService>();
        services.AddSingleton<IEssentialsVersion, EssentialsVersion>();
        services.AddSingleton<IEssentialsDeviceInfo, EssentialsDeviceInfo>();
        services.AddTransient<IBaseService, BaseService>();
        services.AddTransient<IHttpClient, ExtendedHttpClient>();
        services.AddTransient<IHomePageMenuItems, HomePageMenuItemService>();
        services.AddTransient<IBiometricService, BiometricService>();
        services.AddTransient<ITimeoutService, TimeoutService>();
        services.AddTransient<IPermissionService, PermissionService>();
        services.AddTransient<IAnimationService, AnimationService>();
        services.AddTransient<IAlertService, AlertService>();
        services.AddTransient<IAccessibilityService, AccessibilityService>();
        services.AddTransient<Core.INavigationService, NavigationService>();
        services.AddTransient<IConnectFourEngine, ConnectFourEngine>();
        services.AddTransient<ITimerService, TimerService>();
        services.AddTransient<IDeviceLocation, DeviceLocationService>();
        services.AddTransient<IConnectFourDifficultyService, ConnectFourDifficultyService>();
    }

    private static void RegisterAndroidServices(IServiceCollection services)
    {
#if ANDROID
        services.AddTransient<IAnalyticsService, Platforms.Droid.Services.AnalyticsService>();
        services.AddTransient<IRemoteConfigService, Platforms.Droid.Services.RemoteConfigService>();
#endif
    }

    private static void RegisterIosServices(IServiceCollection services)
    {
#if IOS
        services.AddTransient<IAnalyticsService, Platforms.iOS.Services.AnalyticsService>();
        services.AddTransient<IRemoteConfigService, Platforms.iOS.Services.RemoteConfigService>();
#endif
    }
    
    private static void RegisterNavigation(IServiceCollection services)
    {
        services.RegisterForNavigation<InitPage, InitPageViewModel>();
        services.RegisterForNavigation<HomePage, HomePageViewModel>();
        services.RegisterForNavigation<WeatherForecastPage, WeatherForecastPageViewModel>();
        services.RegisterForNavigation<ConnectFourPage, ConnectFourPageViewModel>();
        services.RegisterForNavigation<SnackbarPopup, SnackbarPopupViewModel>();
        services.RegisterForNavigation<GameOverPopupPage, GameOverPopupPageViewModel>();
    }

    private static void RegisterPlaygroundPagesForNavigation(IServiceCollection services)
    {
        services.RegisterForNavigation<PlaygroundPage, PlaygroundPageViewModel>();
        services.RegisterForNavigation<AccessibilityPlaygroundPage, AccessibilityPlaygroundPageViewModel>();
        services.RegisterForNavigation<ButtonsPlaygroundPage, ButtonsPlaygroundPageViewModel>();
        services.RegisterForNavigation<NavigationBarPlaygroundPage, NavigationBarPlaygroundPageViewModel>();
        services.RegisterForNavigation<PopupPagesPlaygroundPage, PopupPagesPlaygroundPageViewModel>();
    }

    private static void RegisterApis(IServiceCollection services)
    {
        services.AddTransient<IOpenWeatherAPI, OpenWeatherAPI>();
    }

    private static void RegisterDataLayers(IServiceCollection services)
    {
        services.AddSingleton<ICurrentWeatherService, WeatherService>();
    }
}