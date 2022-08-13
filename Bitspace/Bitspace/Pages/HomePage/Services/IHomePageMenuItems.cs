using System.Collections.ObjectModel;
using Bitspace.Pages.Mainpage.Models;

namespace Bitspace.Pages.HomePage.Services
{
    public interface IHomePageMenuItems
    {
        public ObservableCollection<MenuListItemViewModel> GetMenuItems();

        public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems();
    }
}
