using System;
using Bitspace.Services.AnimationService;
using Xamarin.Forms;
using System.Buffers;

namespace Bitspace.Controls;
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