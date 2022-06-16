using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Bitspace.Pages.Mainpage.Models;

namespace Bitspace.Pages.Mainpage.Services.MainpageMenuItems
{
    public interface IMainpageMenuItems
    {
        public Task<ObservableCollection<MenuItemModel>> GetMenuItems();
    }
}
