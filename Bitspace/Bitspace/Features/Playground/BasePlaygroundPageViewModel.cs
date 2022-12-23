using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Bitspace.Core;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Features
{
    [ExcludeFromCodeCoverage]
    public class BasePlaygroundPageViewModel : BasePageViewModel
    {
        public BasePlaygroundPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            NavigateBackCommand = new AsyncCommand(NavigateBack);
        }

        public IAsyncCommand NavigateBackCommand { get; }

        private Task NavigateBack()
        {
            return NavigationService.GoBack();
        }
    }
}