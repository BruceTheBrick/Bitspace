using System.Diagnostics.CodeAnalysis;
using Bitspace.Features.Buttons;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class PlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    public PlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }

    [RelayCommand]
    private Task NavigateToAccessibilityPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(AccessibilityPlaygroundPage));
    }

    [RelayCommand]
    private Task NavigateToButtonsPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(ButtonsPlaygroundPage));
    }

    [RelayCommand]
    private Task NavigateToNavigationBarPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(NavigationBarPlaygroundPage));
    }

    [RelayCommand]
    private Task NavigateToPopupPagesPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(PopupPagesPlaygroundPage));
    }
}