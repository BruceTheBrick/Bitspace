using Bitspace.Controls;

namespace Bitspace.Core;

public class AlertService : IAlertService
{
    private readonly INavigationService _navigationService;

    public AlertService(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public Task<INavigationResult> Snackbar(string message)
    {
        var parameters = new NavigationParameters {{NavigationConstants.Message, message},};
        return _navigationService.NavigateAsync(nameof(SnackbarPopup), parameters);
    }

    public async Task Toast(string message)
    {
        // await Application.Current.MainPage.DisplayToastAsync(message);
    }

    public async Task Toast(string message, int milliseconds)
    {
        // await Application.Current.MainPage.DisplayToastAsync(message, milliseconds);
    }

    private IEnumerable<SnackBarActionOptions> MakeActionOptions(IEnumerable<Func<Task>> actions)
    {
        // var actionOptionsList = new List<SnackBarActionOptions>();
        // foreach (var action in actions)
        // {
        //     actionOptionsList.Add(new SnackBarActionOptions {Action = action,});
        // }
        //
        // return actionOptionsList;
        return new List<SnackBarActionOptions>();
    }
}