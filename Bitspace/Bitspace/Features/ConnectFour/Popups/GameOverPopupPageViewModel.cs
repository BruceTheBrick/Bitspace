using System.Threading.Tasks;
using Bitspace.Core;
using Bitspace.Resources;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Features
{
    public class GameOverPopupPageViewModel : BasePageViewModel
    {
        public GameOverPopupPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            PlayAgainCommand = new AsyncCommand(PlayAgain);
            QuitCommand = new AsyncCommand(Quit);
        }

        public IAsyncCommand PlayAgainCommand { get; set; }
        public IAsyncCommand QuitCommand { get; set; }
        public string Winner { get; set; }
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            if (parameters.TryGetValue(NavigationConstants.Winner, out string winner))
            {
                Winner = string.Format(ConnectFourRegister.CF_WINNER, winner);
            }
        }

        private Task PlayAgain()
        {
            var parameters = new NavigationParameters { { NavigationConstants.Reset, true } };
            return NavigationService.GoBack(parameters);
        }

        private Task Quit()
        {
            return NavigationService.NavigateAsync(NavigationConstants.Homepage);
        }
    }
}