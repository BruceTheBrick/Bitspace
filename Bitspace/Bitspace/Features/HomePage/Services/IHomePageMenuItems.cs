using System.Collections.ObjectModel;

namespace Bitspace.Features;

public interface IHomePageMenuItems
{
    public ObservableCollection<MenuListItemViewModel> GetMenuItems();

    public ObservableCollection<MenuListItemViewModel> ForceUpdateGetMenuItems();
}