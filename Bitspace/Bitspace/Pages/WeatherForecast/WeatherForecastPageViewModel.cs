﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Bitspace.APIs;
using Bitspace.Controls;
using Bitspace.Services;
using Prism.Navigation;
using PropertyChanged;

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
        }

        public CurrentWeatherViewModel Weather { get; set; }
        public HourlyForecastViewModel HourlyForecast { get; set; }
        public ObservableCollection<PillViewModel> DailyPillList { get; set; }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            await base.InitializeAsync(parameters);
            InitDailyPillList();
            await UpdateCurrentWeather();
        }

        private async Task UpdateCurrentWeather()
        {
            IsBusy = true;
            Weather = await _currentWeatherService.GetCurrentWeather();
            HourlyForecast = await _currentWeatherService.GetHourlyForecast();
            // InitDailyPillList();
            IsBusy = false;
        }

        private void InitDailyPillList()
        {
            DailyPillList = new ObservableCollection<PillViewModel>();
            // foreach (var pill in HourlyForecast.ForecastItems)
            // {
            //     DailyPillList.Add(new PillViewModel(pill.DisplayText));
            // }
            DailyPillList.Add(new PillViewModel("Pill One"));
            DailyPillList.Add(new PillViewModel("Pill Two"));
            DailyPillList.Add(new PillViewModel("Pill Three"));
            DailyPillList.Add(new PillViewModel("Pill One"));
            DailyPillList.Add(new PillViewModel("Pill Two"));
            DailyPillList.Add(new PillViewModel("Pill Three"));
            DailyPillList.Add(new PillViewModel("Pill One"));
            DailyPillList.Add(new PillViewModel("Pill Two"));
            DailyPillList.Add(new PillViewModel("Pill Three"));
            DailyPillList.Add(new PillViewModel("Pill One"));
            DailyPillList.Add(new PillViewModel("Pill Two"));
            DailyPillList.Add(new PillViewModel("Pill Three"));
        }
    }
}