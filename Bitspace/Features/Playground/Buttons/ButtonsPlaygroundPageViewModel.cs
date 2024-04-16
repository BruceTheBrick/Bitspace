using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features.Buttons;

public partial class ButtonsPlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    public ButtonsPlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
    }

    public bool IsEnabled { get; set; }

    [RelayCommand]
    private void DisplayMessage()
    {
        AlertService.Toast("You pressed the button!");
    }
}