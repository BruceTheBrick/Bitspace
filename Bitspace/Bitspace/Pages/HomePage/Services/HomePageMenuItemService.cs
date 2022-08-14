using System.Collections.ObjectModel;
using Bitspace.Registers;
using Bitspace.Services;

namespace Bitspace.Pages
{
    public class HomePageMenuItemService : IHomePageMenuItems
    {
        private readonly IRemoteConfigService _remoteConfigService;
        public HomePageMenuItemService(IRemoteConfigService remoteConfigService)
        {
            _remoteConfigService = remoteConfigService;
        }

        public ObservableCollection<MenuListItemViewModel> GetMenuItems()
        {
            var items = new ObservableCollection<MenuListItemViewModel>();
            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_WEATHER))
            {
                items.Add(new MenuListItemViewModel
                {
                    Icon = "ic_weather",
                    ActionIcon = "ic_chevron_right",
                    Text = MainpageRegister.WEATHER_FORECAST_TITLE,
                    NavigationConstant = nameof(WeatherForecastPage),
                });
            }

            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_QR_CODE_SCANNER))
            {
                items.Add(new MenuListItemViewModel
                {
                    Icon = "ic_qrcode",
                    ActionIcon = "ic_chevron_right",
                    Text = MainpageRegister.QR_CODE_SCANNER_TITLE,
                    NavigationConstant = nameof(QRCodeScannerPage),
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
