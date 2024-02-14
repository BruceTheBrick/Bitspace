using CommunityToolkit.Maui.Core;

namespace Bitspace.Core;

public class AlertService : IAlertService
{
    public Task ShowSnackbar(string message)
    {
        try
        {
            var defaultOptions = MakeActionOptions();
            return CommunityToolkit.Maui.Alerts.Snackbar.Make(message).Show();

        }
        catch (Exception e)
        {
            
        }
        return Task.CompletedTask;
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
        var options = new SnackbarOptions();
        return options;
    }
}