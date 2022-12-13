using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.APIs;
using Bitspace.Controls;
using Bitspace.Core;
using Bitspace.Resources;
using Bitspace.UI;
using Prism.Navigation;
using PropertyChanged;
using Xamarin.Forms;

namespace Bitspace.Features
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

        public HourlyForecastViewModel HourlyForecast { get; set; }
        public DayViewModel SelectedDayViewModel { get; set; }
        public ObservableCollection<PillViewModel> DailyPillList { get; set; }
        public PillViewModel ActivePill { get; set; }
        public ICommand PillSelectedCommand { get; }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            await base.InitializeAsync(parameters);
            await UpdateCurrentWeather();
        }

        private async Task UpdateCurrentWeather()
        {
            IsBusy = true;
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
                var pill = new PillViewModel(day.DateTime.ToDisplayString());
                pill.Id = Guid.NewGuid().ToString();
                DailyPillList.Add(pill);
            }

            ActivePill = DailyPillList.First();
            ActivePill.IsActive = true;
        }

        private void PillSelected(PillViewModel pill)
        {
            ActivePill.IsActive = false;
            pill.IsActive = true;
            ActivePill = pill;
            SelectedDayViewModel = HourlyForecast.Days.First(x => x.DateTime.ToDisplayString() == pill.Text);
        }
    }
}