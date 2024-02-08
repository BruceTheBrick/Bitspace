using CommunityToolkit.Maui;

namespace Bitspace;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .RegisterTypes()
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>();

        return builder.Build();
    }
}
