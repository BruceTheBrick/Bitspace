﻿using System.Threading.Tasks;
using Bitspace.APIs;

namespace Bitspace.Features
{
    public interface ICurrentWeatherService
    {
        public Task<HourlyForecastViewModel> GetHourlyForecast();
    }
}