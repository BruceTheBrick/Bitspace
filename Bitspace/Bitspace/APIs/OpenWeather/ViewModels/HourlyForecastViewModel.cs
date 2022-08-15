using System.Collections.Generic;

namespace Bitspace.APIs;

public class HourlyForecastViewModel
{
    public HourlyForecastViewModel()
    {
    }

    public HourlyForecastViewModel(HourlyWeatherResponse response)
    {
        InitForecastItems(response.List);
    }

    public List<ForecastItemViewModel> ForecastItems { get; set; }

    private void InitForecastItems(IEnumerable<ListObjectResponse> items)
    {
        ForecastItems = new List<ForecastItemViewModel>();
        foreach (var item in items)
        {
            ForecastItems.Add(new ForecastItemViewModel(item));
        }
    }
}