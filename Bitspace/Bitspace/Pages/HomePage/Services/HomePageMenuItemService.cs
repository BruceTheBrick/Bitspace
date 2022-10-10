using System.Collections.ObjectModel;
using Bitspace.Pages.ConnectFour;
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
                    MainpageRegister.WEATHER_FORECAST_TITLE,
                    "ic_weather",
                    "ic_chevron_right",
                    nameof(WeatherForecastPage)));
            }

            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_MARTINI))
            {
                items.Add(new MenuListItemViewModel(
                    MainpageRegister.MARTINI,
                    "ic_martini",
                    "ic_chevron_right",
                    nameof(ConnectFourPage)));
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
