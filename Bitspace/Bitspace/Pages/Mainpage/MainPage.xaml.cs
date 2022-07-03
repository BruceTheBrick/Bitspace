using Bitspace.Animations;

namespace Bitspace.Pages.Mainpage
{
    public partial class MainPage
    {
        private readonly ScaleAnimations _animations;
        public MainPage()
        {
            InitializeComponent();
            _animations = new ScaleAnimations();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _animations.ScaleIn(AppName);
        }
    }
}
