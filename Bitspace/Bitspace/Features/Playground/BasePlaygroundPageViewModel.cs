using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;

namespace Bitspace.Features;

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