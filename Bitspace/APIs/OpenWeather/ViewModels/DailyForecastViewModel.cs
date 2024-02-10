using Bitspace.Core;

namespace Bitspace.APIs;

public class DailyForecastViewModel
{
    public DailyForecastViewModel(DateTime dateTime, IList<ForecastListObjectResponse> forecastListObjectResponse)
    {
        DisplayDateTime = dateTime.ToDisplayString();
        SetHourlyForecastItems(forecastListObjectResponse);
    }

    public string DisplayDateTime { get; }
    public ForecastItemViewModel SelectedForecastItem { get; set; }
    public IList<ForecastItemViewModel> HourlyForecastItems { get; set; }

    private void SetHourlyForecastItems(IList<ForecastListObjectResponse> forecastItems)
    {
        HourlyForecastItems = new List<ForecastItemViewModel>();
        foreach (var item in forecastItems)
        {
            HourlyForecastItems.Add(new ForecastItemViewModel(item));
        }

        if (HourlyForecastItems != null)
        {
            SelectedForecastItem = HourlyForecastItems.First();
        }
    }
}