using Bitspace.Services.AnimationService;

namespace Bitspace.Pages.WeatherForecast
{
    public partial class WeatherForecastPage
    {
        private readonly AnimationService _animations;
        public WeatherForecastPage()
        {
            _animations = new AnimationService();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _animations.FadeIn(InfoCard, 550);
        }
    }
}