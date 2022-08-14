using System;
using System.Diagnostics.CodeAnalysis;
using Bitspace.Services;
using Xamarin.Forms;

namespace Bitspace.Controls;

[ExcludeFromCodeCoverage]
public partial class AppIcon
{
    private readonly IAnimationService _animationService;
    private bool _isAnimating;
    public AppIcon()
    {
        InitializeComponent();
        _animationService = new AnimationService();
    }

    public Color Color { get; set; }

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
}