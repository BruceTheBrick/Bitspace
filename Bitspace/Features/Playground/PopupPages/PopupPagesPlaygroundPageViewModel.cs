using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class PopupPagesPlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    public PopupPagesPlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }

    public ActionTypeEnum LeftActionType => ActionTypeEnum.Back;

    [RelayCommand]
    private Task ShowGameOverPopupPage()
    {
        var parameters = new NavigationParameters { { NavigationConstants.Winner, "WINNER NAME HERE" } };
        return NavigationService.NavigateAsync(nameof(GameOverPopupPage), parameters, true);
    }
}
