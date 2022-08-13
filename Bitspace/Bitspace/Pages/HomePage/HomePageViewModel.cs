using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Pages.HomePage.Services;
using Bitspace.Pages.Mainpage.Models;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Bitspace.Pages.Mainpage
{
    public class HomePageViewModel : BasePageViewModel
    {
        private readonly IHomePageMenuItems _homePageMenuItemsService;

        public HomePageViewModel(
            INavigationService navigationService,
            IHomePageMenuItems homePageMenuItemsService)
            : base(navigationService)
        {
            _homePageMenuItemsService = homePageMenuItemsService;

            ItemSelectedCommand = new AsyncCommand<MenuListItemViewModel>(ItemSelected);
            RefreshMenuItemsCommand = new Command(RefreshMenuItems);
        }

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
        }

        private void RefreshMenuItems()
        {
            IsRefreshing = true;
            MenuItems = _homePageMenuItemsService.ForceUpdateGetMenuItems();
            IsRefreshing = false;
        }
    }
}
