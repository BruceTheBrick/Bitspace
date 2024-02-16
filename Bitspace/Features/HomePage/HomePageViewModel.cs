using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

public partial class HomePageViewModel : BasePageViewModel
{
    private readonly IHomePageMenuItems _homePageMenuItemsService;
    private readonly IVersionTracking _versionTracking;

    public HomePageViewModel(
        IBaseService baseService,
        IHomePageMenuItems homePageMenuItemsService,
        IVersionTracking version)
        : base(baseService)
    {
        _homePageMenuItemsService = homePageMenuItemsService;
        _versionTracking = version;

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
        AnalyticsService.LogEvent(AnalyticsRegister.ItemSelected, AnalyticsRegister.Id, item.NavigationConstant);
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
        VersionNumber = $"{_versionTracking.CurrentVersion} {_versionTracking.CurrentBuild}";
    }
}