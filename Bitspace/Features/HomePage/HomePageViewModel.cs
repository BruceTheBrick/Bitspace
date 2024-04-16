using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

public partial class HomePageViewModel : BasePageViewModel
{
    private readonly IHomePageMenuItems _homePageMenuItemsService;

    public HomePageViewModel(
        IBaseService baseService,
        IHomePageMenuItems homePageMenuItemsService,
        IVersionTracking versionTracking)
        : base(baseService)
    {
        _homePageMenuItemsService = homePageMenuItemsService;

        VersionNumber = $"{versionTracking.CurrentVersion} {versionTracking.CurrentBuild}";
    }

    public ObservableCollection<MenuListItemViewModel> MenuItems { get; set; }
    public string VersionNumber { get; set; }
    public bool IsRefreshing { get; set; }

    public override void Initialize(INavigationParameters parameters)
    {
        base.Initialize(parameters);
        MenuItems = _homePageMenuItemsService.GetMenuItems();
    }

    [RelayCommand]
    private async Task ItemSelected(MenuListItemViewModel item)
    {
        AnalyticsService.LogEvent(AnalyticsRegister.ItemSelected, AnalyticsRegister.Id, item.NavigationConstant);
        var t = await NavigationService.NavigateAsync(item.NavigationConstant);
    }

    [RelayCommand]
    private void RefreshMenuItems()
    {
        IsRefreshing = true;
        MenuItems = _homePageMenuItemsService.ForceUpdateGetMenuItems();
        IsRefreshing = false;
    }
}