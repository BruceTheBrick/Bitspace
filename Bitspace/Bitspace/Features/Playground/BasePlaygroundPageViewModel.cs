using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class BasePlaygroundPageViewModel : BasePageViewModel
{
    public BasePlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }


    [RelayCommand]
    private Task NavigateBack()
    {
        return NavigationService.GoBack();
    }
}