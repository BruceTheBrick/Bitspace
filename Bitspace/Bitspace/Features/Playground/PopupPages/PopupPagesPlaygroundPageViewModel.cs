using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Bitspace.Core;
using Bitspace.UI;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Features
{
    [ExcludeFromCodeCoverage]
    public class PopupPagesPlaygroundPageViewModel : BasePlaygroundPageViewModel
    {
        public PopupPagesPlaygroundPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            ShowGameOverPopupPageCommand = new AsyncCommand(ShowGameOverPopupPage);
        }

        public ActionTypeEnum LeftActionType => ActionTypeEnum.Back;
        public IAsyncCommand ShowGameOverPopupPageCommand { get; }
        private Task ShowGameOverPopupPage()
        {
            var parameters = new NavigationParameters { { NavigationConstants.Winner, "WINNER NAME HERE" } };
            return NavigationService.NavigateAsync(nameof(GameOverPopupPage), parameters);
        }
    }
}