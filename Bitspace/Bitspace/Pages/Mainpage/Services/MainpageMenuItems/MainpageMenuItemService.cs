using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Bitspace.Constants;
using Bitspace.Pages.Mainpage.Models;
using Bitspace.Registers;
using Bitspace.Services.FirebaseRemoteConfig;

namespace Bitspace.Pages.Mainpage.Services.MainpageMenuItems
{
    public class MainpageMenuItemService : IMainpageMenuItems
    {
        private readonly IFirebaseRemoteConfig _remoteConfigService;
        public MainpageMenuItemService(IFirebaseRemoteConfig remoteConfigService)
        {
            _remoteConfigService = remoteConfigService;
        }

        public async Task<ObservableCollection<MenuListItemViewModel>> GetMenuItems()
        {
            var items = new ObservableCollection<MenuListItemViewModel>();
            if (await _remoteConfigService.IsEnabled(RemoteConfigConstants.MAINPAGE_MENUITEM_WEATHER))
            {
                items.Add(new MenuListItemViewModel
                {
                    Icon = "ic_weather",
                    ActionIcon = "ic_chevron_right",
                    Text = MainpageRegister.WEATHER_FORECAST_TITLE,
                    NavigationConstant = NavigationConstants.WeatherForecast,
                });
            }

            if (await _remoteConfigService.IsEnabled(RemoteConfigConstants.MAINPAGE_MENUITEM_BARCODE_SCANNER))
            {
                items.Add(new MenuListItemViewModel
                {
                    Icon = "ic_barcode",
                    ActionIcon = "ic_chevron_right",
                    Text = MainpageRegister.BARCODE_SCANNER_TITLE,
                    NavigationConstant = NavigationConstants.BarcodeScanner,
                });
            }

            return items;
        }
    }
}
