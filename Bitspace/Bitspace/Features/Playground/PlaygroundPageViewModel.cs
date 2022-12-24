using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Core;
using Bitspace.Features.Buttons;
using Bitspace.Resources;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

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

        private Task NavigateToNavigationBarPlaygroundPage()
        {
            return NavigationService.NavigateAsync(nameof(NavigationBarPlaygroundPage));
        }
    }
}