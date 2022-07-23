using System.Collections.ObjectModel;
using Bitspace.Constants;
using Bitspace.Pages.Mainpage.Models;
using Bitspace.Registers;
using Bitspace.Services.RemoteConfig;

namespace Bitspace.Pages.Mainpage.Services.MainpageMenuItems
{
    public class MainpageMenuItemService : IMainpageMenuItems
    {
        private readonly IRemoteConfigService _remoteConfigService;
        public MainpageMenuItemService(IRemoteConfigService remoteConfigService)
        {
            _remoteConfigService = remoteConfigService;
        }

        public ObservableCollection<MenuListItemViewModel> GetMenuItems()
        {
            var items = new ObservableCollection<MenuListItemViewModel>();
            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.MAINPAGE_MENUITEM_WEATHER))
            {
                items.Add(new MenuListItemViewModel
                {
                    Icon = "ic_weather",
                    ActionIcon = "ic_chevron_right",
                    Text = MainpageRegister.WEATHER_FORECAST_TITLE,
                    NavigationConstant = NavigationConstants.WeatherForecast,
                });
            }

            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.MAINPAGE_MENUITEM_QR_CODE_SCANNER))
            {
                items.Add(new MenuListItemViewModel
                {
                    Icon = "ic_barcode",
                    ActionIcon = "ic_chevron_right",
                    Text = MainpageRegister.QR_CODE_SCANNER_TITLE,
                    NavigationConstant = NavigationConstants.QRCodeScanner,
                });
            }

            return items;
        }

        public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems()
        {
            _remoteConfigService.Update();
            return GetMenuItems();
        }
    }
}
