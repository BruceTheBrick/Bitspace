using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Bitspace.Constants;
using Bitspace.Pages.Mainpage.Models;
using Bitspace.Pages.WeatherForecast;
using Bitspace.Registers;
using Bitspace.Services.FirebaseRemoteConfig;
using Prism.Navigation.Xaml;

namespace Bitspace.Pages.Mainpage.Services.MainpageMenuItems
{
    public class MainpageMenuItemService : IMainpageMenuItems
    {
        private readonly IFirebaseRemoteConfig _remoteConfigService;
        public MainpageMenuItemService(IFirebaseRemoteConfig remoteConfigService)
        {
            _remoteConfigService = remoteConfigService;
        }

        public async Task<ObservableCollection<MenuItemModel>> GetMenuItems()
        {
            var items = new ObservableCollection<MenuItemModel>();
            if (await _remoteConfigService.IsEnabled(RemoteConfigConstants.MAINPAGE_MENUITEM_WEATHER))
            {
                items.Add(new MenuItemModel
                {
                    Image = "image",
                    Title = MainpageRegister.WEATHER_FORECAST_TITLE,
                    Type = NavigationConstants.WeatherForecast,
                });
            }

            return items;
        }
    }
}
