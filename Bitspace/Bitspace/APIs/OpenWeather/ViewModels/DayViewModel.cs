using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bitspace.APIs
{
    [ExcludeFromCodeCoverage]
    public class DayViewModel
    {
        public DayViewModel(DateTime dateTime, IList<ForecastItemViewModel> forecastItems)
        {
            DateTime = dateTime;
            ForecastItems = forecastItems;
        }

        public DateTime DateTime { get; }
        public IList<ForecastItemViewModel> ForecastItems { get; }
    }
}