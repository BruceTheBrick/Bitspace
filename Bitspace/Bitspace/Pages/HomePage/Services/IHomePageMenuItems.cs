using System.Collections.ObjectModel;
using Bitspace.Pages;

namespace Bitspace.Pages
{
    public interface IHomePageMenuItems
    {
        public ObservableCollection<MenuListItemViewModel> GetMenuItems();

        public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems();
    }
}
