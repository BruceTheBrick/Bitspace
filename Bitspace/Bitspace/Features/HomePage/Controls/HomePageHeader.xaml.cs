using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Bitspace.Services;
using Xamarin.Forms;

namespace Bitspace.Features
{
    [ExcludeFromCodeCoverage]
    public partial class HomePageHeader
    {
        private readonly IAnimationService _animationService;
        public HomePageHeader()
        {
            InitializeComponent();
            _animationService = new AnimationService();
            AppIcon.Opacity = 0;
            _ = StartAnimation();
        }

        private async Task StartAnimation()
        {
            await _animationService.ScaleIn(AppName);
            await AnimateIcon();
        }

        private async Task HideIcon()
        {
            await AppIcon.TranslateTo(-AppIcon.Width, AppIcon.Height, 0);
        }

        private async Task AnimateIcon()
        {
            await HideIcon();
            _ = _animationService.FadeIn(AppIcon, 250);
            await AppIcon.TranslateTo(0, 0, 750, Easing.CubicInOut);
        }
    }
}