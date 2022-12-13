using Bitspace.Core;
using Prism.Navigation;
using Xamarin.Forms;

namespace Bitspace.Features
{
    public class InitPageViewModel : INavigatedAware
    {
        private readonly IBaseService _baseService;
        protected InitPageViewModel(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            _ = _baseService.NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(HomePage)}");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}