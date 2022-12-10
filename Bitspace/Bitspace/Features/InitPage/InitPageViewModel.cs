using System.Threading.Tasks;
using Bitspace.Core;
using Prism.Navigation;
using Xamarin.Forms;

namespace Bitspace.Features
{
    public class InitPageViewModel : BasePageViewModel
    {
        private readonly IRemoteConfigService _remoteConfigService;
        protected InitPageViewModel(IBaseService baseService, IRemoteConfigService remoteConfigService)
            : base(baseService)
        {
            _remoteConfigService = remoteConfigService;
        }

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);
            await _remoteConfigService.FetchAndActivate();
            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(HomePage)}");
        }
    }
}