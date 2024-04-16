using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Bitspace.iOS.Services;
using Prism;
using Prism.Ioc;

namespace Bitspace.iOS;

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
        containerRegister.Register<IAnalyticsService, AnalyticsService>();
        containerRegister.Register<IRemoteConfigService, RemoteConfigService>();
    }

    private void InitHelpers()
    {
        Core.Accessibility.Current = new Helpers.AccessibilityImplementation();
    }
}