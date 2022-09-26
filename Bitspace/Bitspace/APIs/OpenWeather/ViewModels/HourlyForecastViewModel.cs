using System.Collections.Generic;
using System.Linq;

namespace Bitspace.APIs
{

    public class HourlyForecastViewModel
    {
        public HourlyForecastViewModel()
        {
        }

        public HourlyForecastViewModel(HourlyWeatherResponse response)
        {
            InitForecastItems(response.List);
            InitDays();
        }

        public IList<ForecastItemViewModel> ForecastItems { get; set; }
        public IList<DayViewModel> Days { get; set; }

        private void InitForecastItems(IEnumerable<ListObjectResponse> items)
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
                    day.ForecastItems.Add(item);
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
}