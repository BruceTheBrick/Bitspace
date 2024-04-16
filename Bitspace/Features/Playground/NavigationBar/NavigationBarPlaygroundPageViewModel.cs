using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class NavigationBarPlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    public NavigationBarPlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }

    public ActionTypeEnum LeftActionType { get; set; }
    public ActionTypeEnum RightActionType { get; set; }
    public bool IsLeftActionToggled { get; set; }
    public bool IsRightActionToggled { get; set; }

    [RelayCommand]
    private void SetLeftActionType(ActionTypeEnum actionType)
    {
        LeftActionType = actionType;
    }

    [RelayCommand]
    private void SetRightActionType(ActionTypeEnum actionType)
    {
        RightActionType = actionType;
    }
}