using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class HomePageHeader
{
    private readonly IAnimationService _animationService;
    private bool _isAnimating;
    public HomePageHeader()
    {
        InitializeComponent();
        _animationService = new AnimationService();
        // AppIcon.Opacity = 0;
        // _ = StartAnimation();
    }

    public string AccessibilityName => $"{HomePageRegister.WelcomeTo} {HomePageRegister.Bitspace}";

    private async void RotateIcon(object sender, EventArgs e)
    {
        if (_isAnimating)
        {
            return;
        }

        _isAnimating = true;
        await _animationService.Spin(sender as View);
        _isAnimating = false;
    }

    private async Task StartAnimation()
    {
        await _animationService.ScaleIn(AppName);
        await AnimateIcon();
    }

    private async Task HideIcon()
    {
        // await AppIcon.TranslateTo(-AppIcon.Width, AppIcon.Height, 0);
    }

    private async Task AnimateIcon()
    {
        await HideIcon();
        // _ = _animationService.FadeIn(AppIcon, 250);
        // await AppIcon.TranslateTo(0, 0, 750, Easing.CubicInOut);
    }
}