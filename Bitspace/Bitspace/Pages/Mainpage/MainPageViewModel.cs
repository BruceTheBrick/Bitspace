using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Pages.Mainpage.Models;
using Bitspace.Pages.Mainpage.Services.MainpageMenuItems;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Bitspace.Pages.Mainpage
{
    public class MainPageViewModel : BasePageViewModel
    {
        private readonly IMainpageMenuItems _mainpageMenuItemsService;

        public MainPageViewModel(
            INavigationService navigationService,
            IMainpageMenuItems mainpageMenuItemsService)
            : base(navigationService)
        {
            _mainpageMenuItemsService = mainpageMenuItemsService;

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
            MenuItems = _mainpageMenuItemsService.GetMenuItems();
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
            MenuItems = _mainpageMenuItemsService.ForceUpdateGetMenuItems();
            IsRefreshing = false;
        }
    }
}
