using System.Diagnostics.CodeAnalysis;
using Bitspace.UI;

namespace Bitspace.Controls;

[ExcludeFromCodeCoverage]
public partial class SnackbarPopup
{
    public SnackbarPopup()
    {
        InitializeComponent();
    }

    private async void SwipeGestureRecognizer_OnSwiped(object sender, SwipedEventArgs e)
    {
        if (e.Direction == SwipeDirection.Left)
        {
            await SlideLeft();
        }
        else
        {
            await SlideRight();
        }

        if (BindingContext is SnackbarPopupViewModel viewModel)
        {
            await viewModel.DismissCommand.ExecuteAsync(null);
        }
    }

    private Task SlideLeft()
    {
        return Frame.TranslateTo(-Frame.Width, 0, 200);
    }

    private Task SlideRight()
    {
        return Frame.TranslateTo(Frame.Width, 0, 200);
    }
}