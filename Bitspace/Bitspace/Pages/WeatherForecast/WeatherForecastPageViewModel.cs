using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.APIs;
using Bitspace.Controls;
using Bitspace.Extensions;
using Bitspace.Services;
using Prism.Navigation;
using PropertyChanged;
using Xamarin.Forms;

namespace Bitspace.Pages
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherForecastPageViewModel : BasePageViewModel
    {
        private readonly ICurrentWeatherService _currentWeatherService;

        public WeatherForecastPageViewModel(
            IBaseService baseService,
            ICurrentWeatherService currentWeatherService)
            : base(baseService)
        {
            _currentWeatherService = currentWeatherService;
            PillSelectedCommand = new Command<PillViewModel>(PillSelected);
        }

        public CurrentWeatherViewModel Weather { get; set; }
        public HourlyForecastViewModel HourlyForecast { get; set; }
        public DayViewModel SelectedDayViewModel { get; set; }
        public ObservableCollection<PillViewModel> DailyPillList { get; set; }
        public ICommand PillSelectedCommand { get; }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            await base.InitializeAsync(parameters);
            await UpdateCurrentWeather();
        }

        private async Task UpdateCurrentWeather()
        {
            IsBusy = true;
            Weather = await _currentWeatherService.GetCurrentWeather();
            HourlyForecast = await _currentWeatherService.GetHourlyForecast();
            SelectedDayViewModel = HourlyForecast.Days.First();
            InitDailyPillList();
            IsBusy = false;
        }

        private void InitDailyPillList()
        {
            DailyPillList = new ObservableCollection<PillViewModel>();
            foreach (var day in HourlyForecast.Days)
            {
                DailyPillList.Add(new PillViewModel(day.DateTime.ToDisplayString()));
            }
        }

        private void PillSelected(PillViewModel pill)
        {
            var newDay = HourlyForecast.Days.First(x => x.DateTime.ToDisplayString() == pill.Text);
        }
    }
}