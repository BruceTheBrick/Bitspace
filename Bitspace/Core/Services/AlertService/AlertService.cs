using Bitspace.Resources;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Bitspace.Core;

public class AlertService : IAlertService
{
    public Task ShowSnackbar(string message)
    {
        var defaultOptions = MakeActionOptions();
        return Snackbar.Make(message, null, string.Empty, visualOptions: defaultOptions).Show();
    }

    public async Task Toast(string message)
    {
        // await Application.Current.MainPage.DisplayToastAsync(message);
    }

    public async Task Toast(string message, int milliseconds)
    {
        // await Application.Current.MainPage.DisplayToastAsync(message, milliseconds);
    }

    private SnackbarOptions MakeActionOptions()
    {
        var options = new SnackbarOptions
        {
            BackgroundColor = ResourceHelper.GetResource<ColorRef>("SnackbarBackgroundColor"),
        };
        return options;
    }
}