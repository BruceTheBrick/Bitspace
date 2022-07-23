using System.Collections.ObjectModel;
using Bitspace.Pages.Mainpage.Models;

namespace Bitspace.Pages.Mainpage.Services.MainpageMenuItems
{
    public interface IMainpageMenuItems
    {
        public ObservableCollection<MenuListItemViewModel> GetMenuItems();

        public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems();
    }
}
