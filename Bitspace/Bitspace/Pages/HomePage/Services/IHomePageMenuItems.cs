using System.Collections.ObjectModel;

namespace Bitspace.Pages
{
    public interface IHomePageMenuItems
    {
        public ObservableCollection<MenuListItemViewModel> GetMenuItems();

        public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems();
    }
}
