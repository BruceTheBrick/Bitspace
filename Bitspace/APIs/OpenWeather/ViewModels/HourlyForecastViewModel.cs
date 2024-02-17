namespace Bitspace.APIs;

public class HourlyForecastViewModel
{
    public HourlyForecastViewModel()
    {
        Location = new LocationViewModel();
    }

    public HourlyForecastViewModel(HourlyWeatherResponse response)
    {
        InitForecastItems(response.List);
        InitDays();
        Location = new LocationViewModel();
    }

    public IList<ForecastItemViewModel> ForecastItems { get; set; }
    public IList<DayViewModel> Days { get; set; }
    public LocationViewModel Location { get; set; }

    private void InitForecastItems(IEnumerable<ForecastListObjectResponse> items)
    {
        ForecastItems = new List<ForecastItemViewModel>();
        foreach (var item in items)
        {
            ForecastItems.Add(new ForecastItemViewModel(item));
        }
    }

    private void InitDays()
    {
        Days = new List<DayViewModel>();
        foreach (var item in ForecastItems)
        {
            if (Days.Any(x => x.DateTime.Date == item.DateTime.Date))
            {
                var day = Days.First(x => x.DateTime.Date == item.DateTime.Date);
                day.AddForecastItem(item);
            }
            else
            {
                var forecastItems = new List<ForecastItemViewModel> { item };
                var newDay = new DayViewModel(item.DateTime, forecastItems);
                Days.Add(newDay);
            }
        }
    }
}