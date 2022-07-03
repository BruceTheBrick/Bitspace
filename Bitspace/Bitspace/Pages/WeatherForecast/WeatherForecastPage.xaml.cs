using Bitspace.Animations;

namespace Bitspace.Pages.WeatherForecast
{
    public partial class WeatherForecastPage
    {
        private AnimationHelper _animations;
        public WeatherForecastPage()
        {
            _animations = new AnimationHelper();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _animations.FadeIn(InfoCard, 550);
        }
    }
}