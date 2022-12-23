using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Bitspace.Core;
using Bitspace.Features.Buttons;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Features
{
    [ExcludeFromCodeCoverage]
    public class PlaygroundPageViewModel : BasePlaygroundPageViewModel
    {
        protected PlaygroundPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            NavigateToAccessibilityPlaygroundPageCommand = new AsyncCommand(NavigateToAccessibilityPlaygroundPage);
            NavigateToButtonsPlaygroundPageCommand = new AsyncCommand(NavigateToButtonsPlaygroundPage);
            NavigateToNavigationBarPlaygroundPageCommand = new AsyncCommand(NavigateToNavigationBarPlaygroundPage);
        }

        public IAsyncCommand NavigateToAccessibilityPlaygroundPageCommand { get; }
        public IAsyncCommand NavigateToButtonsPlaygroundPageCommand { get; }
        public IAsyncCommand NavigateToNavigationBarPlaygroundPageCommand { get; }

        private Task NavigateToAccessibilityPlaygroundPage()
        {
            return NavigationService.NavigateAsync(nameof(AccessibilityPlaygroundPage));
        }

        private Task NavigateToButtonsPlaygroundPage()
        {
            return NavigationService.NavigateAsync(nameof(ButtonsPlaygroundPage));
        }

        private async Task NavigateToNavigationBarPlaygroundPage()
        {
            var t = await NavigationService.NavigateAsync(nameof(NavigationBarPlaygroundPage));
        }
    }
}