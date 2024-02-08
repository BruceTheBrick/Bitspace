using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Bitspace.Core;
using Bitspace.UI;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public class NavigationBarPlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    public NavigationBarPlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
        SetLeftActionTypeCommand = new Command<ActionTypeEnum>(SetLeftActionType);
        SetRightActionTypeCommand = new Command<ActionTypeEnum>(SetRightActionType);
    }

    public ICommand SetLeftActionTypeCommand { get; }
    public ICommand SetRightActionTypeCommand { get; set; }
    public ActionTypeEnum LeftActionType { get; set; }
    public ActionTypeEnum RightActionType { get; set; }
    public bool IsLeftActionToggled { get; set; }
    public bool IsRightActionToggled { get; set; }

    private void SetLeftActionType(ActionTypeEnum actionType)
    {
        LeftActionType = actionType;
    }

    private void SetRightActionType(ActionTypeEnum actionType)
    {
        RightActionType = actionType;
    }
}