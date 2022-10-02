using System.Threading.Tasks;
using Prism.Navigation;

namespace Bitspace.Services.NavigationService
{

    public interface INavigationService
    {
        public Task<INavigationResult> NavigateAsync(string url);

        public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters);

        public Task<INavigationResult> NavigateAsync(string url, bool useModalNavigation);

        public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters, bool useModalNavigation);
    }
}