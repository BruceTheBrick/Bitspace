using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Bitspace.Core;

public class AlertService : IAlertService
{
    public Task ShowSnackbar(string message)
    {
        var defaultOptions = MakeActionOptions();
        var snackbar = Snackbar.Make(message, null, string.Empty, visualOptions: defaultOptions);
        return snackbar.Show();
    }

    public Task Toast(string message)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make(message, ToastDuration.Long);
        return toast.Show();
    }

    public Task Toast(string message, ToastDuration duration)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make(message, duration);
        return toast.Show();
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