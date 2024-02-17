using System.Diagnostics.CodeAnalysis;
using Bitspace.Features.Buttons;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Fingerprint;

namespace Bitspace;

[ExcludeFromCodeCoverage]
public static class PlatformInitializer
{
    public static MauiAppBuilder Initialize(this MauiAppBuilder builder)
    {
        builder.UsePrism(
            DryIocContainerExtension.DefaultRules.WithoutUseInterpretation(),
            prismBuilder =>
            {
                prismBuilder.CreateWindow(NavigationConstants.Homepage);
            });

        RegisterLifecycleEvents(builder);
        RegisterServices(builder.Services);
        RegisterApis(builder.Services);
        RegisterDataLayers(builder.Services);
        RegisterNavigation(builder.Services);
        RegisterPlaygroundPagesForNavigation(builder.Services);
        return builder;
    }

    private static void RegisterLifecycleEvents(MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
            RegisterAndroidLifecycleEvents(events);
            RegisterIosLifecycleEvents(events);
        });
    }

    private static void RegisterIosLifecycleEvents(ILifecycleBuilder events)
    {
#if IOS
        events.AddiOS(iosEvents =>
        {
        });
#endif
    }

    private static void RegisterAndroidLifecycleEvents(ILifecycleBuilder events)
    {
#if ANDROID
        events.AddAndroid(androidEvents =>
        {
            androidEvents.OnCreate((activity, _) =>
            {
                Firebase.FirebaseApp.InitializeApp(activity);
                if (activity is Platforms.Droid.MainActivity mainActivity)
                {
                    CrossFingerprint.SetCurrentActivityResolver(() => mainActivity);
                }
            });
        });
#endif
    }

    private static void RegisterServices(IServiceCollection services)
    {
        RegisterAndroidServices(services);
        RegisterIosServices(services);
        // services.AddSingleton<IAppInfo, AppInfo>();
        services.AddTransient(_ => Preferences.Default);
        services.AddTransient(_ => VersionTracking.Default);
        services.AddSingleton<IApiKeyManagerService, ApiKeyManagerService>();
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
        RegisterAndroidHelpers();
        services.AddTransient<IAnalyticsService, Platforms.Droid.Services.AnalyticsService>();
        services.AddTransient<IRemoteConfigService, Platforms.Droid.Services.RemoteConfigService>();
#endif
    }

    private static void RegisterAndroidHelpers()
    {
#if ANDROID
        Accessibility.Current = new Platforms.Droid.Helpers.AccessibilityImplementation();
#endif
    }

    private static void RegisterIosServices(IServiceCollection services)
    {
#if IOS
        RegisterIosHelpers();
        services.AddTransient<IAnalyticsService, Platforms.iOS.Services.AnalyticsService>();
        services.AddTransient<IRemoteConfigService, Platforms.iOS.Services.RemoteConfigService>();
#endif
    }

    private static void RegisterIosHelpers()
    {
#if IOS
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