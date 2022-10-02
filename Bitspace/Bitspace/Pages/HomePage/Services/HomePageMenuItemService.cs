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
                items.Add(new MenuListItemViewModel(
                    "ic_weather",
                    "ic_chevron_right",
                    MainpageRegister.WEATHER_FORECAST_TITLE,
                    nameof(WeatherForecastPage)));
            }

            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_QR_CODE_SCANNER))
            {
                items.Add(new MenuListItemViewModel(
                    "ic_qrcode",
                    "ic_chevron_right",
                    MainpageRegister.QR_CODE_SCANNER_TITLE,
                    nameof(QRCodeScannerPage)));
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
