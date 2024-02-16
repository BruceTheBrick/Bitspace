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
    private async Task ShowGameOverPopupPage()
    {
        var parameters = new NavigationParameters { { NavigationConstants.Winner, "WINNER NAME HERE" } };
        var t = await NavigationService.NavigateAsync(nameof(GameOverPopupPage), parameters);
    }
}
