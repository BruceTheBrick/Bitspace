using System;
using System.Collections.Generic;
using System.Linq;

namespace Bitspace.APIs;

public class DailyForecastViewModel
{
    public DailyForecastViewModel()
    {
    }

    public DailyForecastViewModel(DateTime dateTime, IList<ListObjectResponse> HourlyForecastItemResponse)
    {
        SetDisplayTextDateTime(dateTime);
        SetHourlyForecastItems(HourlyForecastItemResponse);
    }

    public string DisplayDateTime { get; set; }
    public ForecastItemViewModel SelectedForecastItem { get; set; }
    public IList<ForecastItemViewModel> HourlyForecastItems { get; set; }

    private void SetHourlyForecastItems(IList<ListObjectResponse> forecastItems)
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

    private void SetDisplayTextDateTime(DateTime dateTime)
    {
        var dayName = dateTime.ToString("dddd");
        var shortMonth = dateTime.ToString("MMM");
        var date = dateTime.Day;
        DisplayDateTime = $"{dayName}, {date} {shortMonth}";
    }
}