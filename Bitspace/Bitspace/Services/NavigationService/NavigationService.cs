using System.Threading.Tasks;
using Prism.Navigation;

namespace Bitspace.Services.NavigationService
{
    public class NavigationService : INavigationService
    {
        private readonly Prism.Navigation.INavigationService _navigationService;
        public NavigationService(Prism.Navigation.INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Task<INavigationResult> NavigateAsync(string url)
        {
            return _navigationService.NavigateAsync(url, null, false, true);
        }

        public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters)
        {
            return _navigationService.NavigateAsync(url, parameters, false, true);
        }

        public Task<INavigationResult> NavigateAsync(string url, bool useModalNavigation)
        {
            return _navigationService.NavigateAsync(url, null, useModalNavigation, true);
        }

        public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters, bool useModalNavigation)
        {
            return _navigationService.NavigateAsync(url, parameters, useModalNavigation, false);
        }
    }
}