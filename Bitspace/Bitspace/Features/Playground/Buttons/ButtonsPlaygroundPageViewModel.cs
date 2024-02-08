using Bitspace.Core;

namespace Bitspace.Features.Buttons;

public class ButtonsPlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    public ButtonsPlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }

    public bool IsEnabled { get; set; }
}