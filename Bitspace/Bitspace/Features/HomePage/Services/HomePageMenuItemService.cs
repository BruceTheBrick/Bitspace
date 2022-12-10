using System.Collections.ObjectModel;
using Bitspace.Core;
using Bitspace.Resources;

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
            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_WEATHER))
            {
                items.Add(new MenuListItemViewModel(
                    HomePageRegister.WEATHER_FORECAST_TITLE,
                    "ic_weather",
                    "ic_chevron_right",
                    nameof(WeatherForecastPage)));
            }

            if (_remoteConfigService.IsEnabled(RemoteConfigConstants.HOMEPAGE_MENUITEM_MARTINI))
            {
                items.Add(new MenuListItemViewModel(
                    HomePageRegister.MARTINI,
                    "ic_martini",
                    "ic_chevron_right",
                    nameof(ConnectFourPage)));
            }

            items.Add(new MenuListItemViewModel(
                "Playground",
                "ic_info",
                "ic_chevron_right",
                nameof(PlaygroundPage)));

            return items;
        }

        public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems()
        {
            _remoteConfigService.FetchAndActivate();
            return GetMenuItems();
        }
    }
}
