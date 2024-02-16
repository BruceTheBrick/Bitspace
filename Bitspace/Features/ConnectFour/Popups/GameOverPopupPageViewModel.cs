using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

public partial class GameOverPopupPageViewModel : BasePageViewModel
{
    public GameOverPopupPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }

    public string Winner { get; set; }

    public override void Initialize(INavigationParameters parameters)
    {
        base.Initialize(parameters);
        if (parameters.TryGetValue(NavigationConstants.Winner, out string winner))
        {
            Winner = string.Format(ConnectFourRegister.Winner, winner);
        }
    }

    [RelayCommand]
    private Task PlayAgain()
    {
        var parameters = new NavigationParameters { { NavigationConstants.Reset, true } };
        return NavigationService.GoBack(parameters, true);
    }

    [RelayCommand]
    private Task Quit()
    {
        return NavigationService.GoBack(true);
    }
}