using System.Collections.ObjectModel;
using Bitspace.Core;
using Bitspace.Resources.Registers.Copy;

namespace Bitspace.Features;

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
        if (_remoteConfigService.IsEnabled(RemoteConfigConstants.Homepage_Weather))
        {
            items.Add(new MenuListItemViewModel(
                HomePageRegister.WEATHER_FORECAST_TITLE,
                "ic_weather",
                "ic_chevron_right",
                nameof(WeatherForecastPage)));
        }

        if (_remoteConfigService.IsEnabled(RemoteConfigConstants.Homepage_Martini))
        {
            items.Add(new MenuListItemViewModel(
                HomePageRegister.MARTINI,
                "ic_martini",
                "ic_chevron_right",
                nameof(ConnectFourPage)));
        }

        if (_remoteConfigService.IsEnabled(RemoteConfigConstants.Homepage_Playground))
        {
            items.Add(new MenuListItemViewModel(
                "Playground",
                "ic_info",
                "ic_chevron_right",
                nameof(PlaygroundPage)));
        }

        return items;
    }

    public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems()
    {
        _remoteConfigService.FetchAndActivate();
        return GetMenuItems();
    }
}