using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Services;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Bitspace.Pages
{
    public class HomePageViewModel : BasePageViewModel
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
            ItemSelectedCommand = new AsyncCommand<MenuListItemViewModel>(ItemSelected);
            RefreshMenuItemsCommand = new Command(RefreshMenuItems);
        }

        public string VersionNumber { get; set; }
        public ObservableCollection<MenuListItemViewModel> MenuItems { get; set; }
        public ICommand ItemSelectedCommand { get; }
        public ICommand RefreshMenuItemsCommand { get; }
        public bool IsRefreshing { get; set; }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            MenuItems = _homePageMenuItemsService.GetMenuItems();
        }

        private async Task ItemSelected(MenuListItemViewModel item)
        {
            if (!string.IsNullOrEmpty(item.NavigationConstant))
            {
                await NavigationService.NavigateAsync(item.NavigationConstant);
            }

            AnalyticsService.LogEvent("BUTTON_PRESSED", "ID", "MENU_BUTTON_PRESSED");
        }

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
}
