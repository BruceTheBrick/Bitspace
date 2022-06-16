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
            MenuTileSelectedCommand = new AsyncCommand<MenuItemModel>(MenuTileSelected);
        }

        public ObservableCollection<MenuItemModel> MenuItems { get; set; }
        public ICommand MenuTileSelectedCommand { get; }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            MenuItems = await _mainpageMenuItemsService.GetMenuItems();
        }

        private async Task MenuTileSelected(MenuItemModel item)
        {
            await NavigationService.NavigateAsync(item.Type);
        }
    }
}
