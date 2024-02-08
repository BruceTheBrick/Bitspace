using Bitspace.Core;

namespace Bitspace.Features;

public class InitPageViewModel : BasePageViewModel
{
    public InitPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }

    public override async Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        await NavigationService.NavigateAsync(NavigationConstants.Homepage);
    }
}