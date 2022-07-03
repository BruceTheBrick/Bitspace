using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Pages.Mainpage.Models;
using Bitspace.Pages.Mainpage.Services.MainpageMenuItems;
using Bitspace.Registers;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

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
        }

        public ObservableCollection<MenuListItemViewModel> MenuItems { get; set; }
        public ICommand ItemSelectedCommand { get; }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            MenuItems = await _mainpageMenuItemsService.GetMenuItems();
        }

        private async Task ItemSelected(MenuListItemViewModel item)
        {
            if (!string.IsNullOrEmpty(item.NavigationConstant))
            {
                await NavigationService.NavigateAsync(item.NavigationConstant);
            }
        }
    }
}
