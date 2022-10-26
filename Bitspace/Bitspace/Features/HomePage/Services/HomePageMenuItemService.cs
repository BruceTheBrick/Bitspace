using System.Collections.ObjectModel;
using Bitspace.Resources;
using Bitspace.Services;

namespace Bitspace.Features
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
            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_WEATHER) || true)
            {
                items.Add(new MenuListItemViewModel(
                    HomePageRegister.WEATHER_FORECAST_TITLE,
                    "ic_weather",
                    "ic_chevron_right",
                    nameof(WeatherForecastPage)));
            }

            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_MARTINI) || true)
            {
                items.Add(new MenuListItemViewModel(
                    HomePageRegister.MARTINI,
                    "ic_martini",
                    "ic_chevron_right",
                    nameof(ConnectFourPage)));
            }

            return items;
        }

        public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems()
        {
            _remoteConfigService.FetchAndActivate();
            return GetMenuItems();
        }
    }
}
