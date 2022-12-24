using System;
using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Xamarin.Forms;

namespace Bitspace.UI
{
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
}