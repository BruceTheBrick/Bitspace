using System.Collections.ObjectModel;
using Bitspace.APIs;
using Bitspace.Core;
using Bitspace.UI;
using CommunityToolkit.Mvvm.Input;
using PropertyChanged;

namespace Bitspace.Features;

[AddINotifyPropertyChangedInterface]
public partial class WeatherForecastPageViewModel : BasePageViewModel
{
    private readonly ICurrentWeatherService _currentWeatherService;

    public WeatherForecastPageViewModel(
        IBaseService baseService,
        ICurrentWeatherService currentWeatherService)
        : base(baseService)
    {
        _currentWeatherService = currentWeatherService;
    }

    public HourlyForecastViewModel HourlyForecast { get; set; }
    public DayViewModel SelectedDayViewModel { get; set; }
    public ObservableCollection<PillViewModel> DailyPillList { get; set; }
    public PillViewModel ActivePill { get; set; }

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

    [RelayCommand]
    private void PillSelected(PillViewModel pill)
    {
        ActivePill.IsActive = false;
        pill.IsActive = true;
        ActivePill = pill;
        SelectedDayViewModel = HourlyForecast.Days.First(x => x.DateTime.ToDisplayString() == pill.Text);
    }

    [RelayCommand]
    private Task NavigateBack()
    {
        return NavigationService.GoBack();
    }
}