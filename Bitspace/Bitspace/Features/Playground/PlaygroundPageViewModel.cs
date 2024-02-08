using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Bitspace.Features.Buttons;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public class PlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    protected PlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
        NavigateToAccessibilityPlaygroundPageCommand = new AsyncCommand(NavigateToAccessibilityPlaygroundPage);
        NavigateToButtonsPlaygroundPageCommand = new AsyncCommand(NavigateToButtonsPlaygroundPage);
        NavigateToNavigationBarPlaygroundPageCommand = new AsyncCommand(NavigateToNavigationBarPlaygroundPage);
        NavigateToPopupPagesPlaygroundPageCommand = new AsyncCommand(NavigateToPopupPagesPlaygroundPage);
    }

    public IAsyncCommand NavigateToAccessibilityPlaygroundPageCommand { get; }
    public IAsyncCommand NavigateToButtonsPlaygroundPageCommand { get; }
    public IAsyncCommand NavigateToNavigationBarPlaygroundPageCommand { get; }
    public IAsyncCommand NavigateToPopupPagesPlaygroundPageCommand { get; }

    private Task NavigateToAccessibilityPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(AccessibilityPlaygroundPage));
    }

    private Task NavigateToButtonsPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(ButtonsPlaygroundPage));
    }

    private Task NavigateToNavigationBarPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(NavigationBarPlaygroundPage));
    }

    private Task NavigateToPopupPagesPlaygroundPage()
    {
        return NavigationService.NavigateAsync(nameof(PopupPagesPlaygroundPage));
    }
}