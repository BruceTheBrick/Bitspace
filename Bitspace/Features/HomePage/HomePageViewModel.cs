using System.Collections.ObjectModel;
using Bitspace.Core;
using Bitspace.Resources.Registers.Analytics;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

public partial class HomePageViewModel : BasePageViewModel
{
    private readonly IHomePageMenuItems _homePageMenuItemsService;
    private readonly IEssentialsVersion _essentialsVersionService;

    public HomePageViewModel(
        IBaseService baseService,
        IHomePageMenuItems homePageMenuItemsService,
        IEssentialsVersion essentialsVersion)
        : base(baseService)
    {
        _homePageMenuItemsService = homePageMenuItemsService;
        _essentialsVersionService = essentialsVersion;

        SetVersionNumber();
    }

    public string VersionNumber { get; set; }
    public ObservableCollection<MenuListItemViewModel> MenuItems { get; set; }
    public bool IsRefreshing { get; set; }

    public override void Initialize(INavigationParameters parameters)
    {
        base.Initialize(parameters);
        MenuItems = _homePageMenuItemsService.GetMenuItems();
    }

    [RelayCommand]
    private Task ItemSelected(MenuListItemViewModel item)
    {
        AnalyticsService.LogEvent(AnalyticsRegister.ITEM_SELECTED, AnalyticsRegister.ID, item.NavigationConstant);
        return NavigationService.NavigateAsync(item.NavigationConstant);
    }

    [RelayCommand]
    private void RefreshMenuItems()
    {
        IsRefreshing = true;
        MenuItems = _homePageMenuItemsService.ForceUpdateGetMenuItems();
        IsRefreshing = false;
    }

    private void SetVersionNumber()
    {
        VersionNumber =
            $"{_essentialsVersionService.CurrentVersion()} {_essentialsVersionService.CurrentBuildNumber()}";
    }
}