using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Core;
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
        }

        public ICommand NavigateToAccessibilityPlaygroundPageCommand { get; }
        protected override string PageName { get; set; } = "Playground Page";

        private Task NavigateToAccessibilityPlaygroundPage()
        {
            return NavigationService.NavigateAsync(nameof(AccessibilityPlaygroundPage));
        }

    }
}