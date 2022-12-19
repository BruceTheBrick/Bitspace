using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Core;
using Bitspace.Features.Buttons;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Features
{
    [ExcludeFromCodeCoverage]
    public class PlaygroundPageViewModel : BasePageViewModel
    {
        protected PlaygroundPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            NavigateToAccessibilityPlaygroundPageCommand = new AsyncCommand(NavigateToAccessibilityPlaygroundPage);
            NavigateToButtonsPlaygroundPageCommand = new AsyncCommand(NavigateToButtonsPlaygroundPage);
        }

        public IAsyncCommand NavigateToAccessibilityPlaygroundPageCommand { get; }
        public IAsyncCommand NavigateToButtonsPlaygroundPageCommand { get; }

        private Task NavigateToAccessibilityPlaygroundPage()
        {
            return NavigationService.NavigateAsync(nameof(AccessibilityPlaygroundPage));
        }

        private Task NavigateToButtonsPlaygroundPage()
        {
            return NavigationService.NavigateAsync(nameof(ButtonsPlaygroundPage));
        }
    }
}