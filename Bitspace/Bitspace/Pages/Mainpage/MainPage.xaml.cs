using System.Threading.Tasks;
using Bitspace.Services.AnimationService;
using Xamarin.Forms;

namespace Bitspace.Pages.Mainpage
{
    public partial class MainPage
    {
        private readonly IAnimationService _animationService;
        public MainPage(IAnimationService animationService)
        {
            InitializeComponent();
            _animationService = animationService;

            AppIcon.Opacity = 0;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(300);
            _ = _animationService.ScaleIn(AppName);
            _ = AnimateIcon();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _ = _animationService.FadeOut(AppIcon);
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
