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
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double RainChance { get; set; }

        public void AddForecastItem(ForecastItemViewModel item)
        {
            ForecastItems.Add(item);
            CalculateAverages();
        }

        private void CalculateAverages()
        {
            var temp = 0.0;
            var windSpeed = 0.0;
            var humidity = 0.0;
            var rainChance = 0.0;
            foreach (var item in ForecastItems)
            {
                temp += item.Temperature;
                windSpeed += item.WindSpeed;
                humidity += item.Humidity;
                rainChance += item.RainChance;
            }

            if (ForecastItems.Count == 0)
            {
                Temperature = 0;
                WindSpeed = 0;
                Humidity = 0;
                RainChance = 0;
            }
            else
            {
                Temperature = Math.Round(temp / ForecastItems.Count, 2);
                WindSpeed = Math.Round(windSpeed / ForecastItems.Count, 2);
                Humidity = Math.Round(humidity / ForecastItems.Count, 2);
                RainChance = Math.Round(rainChance / ForecastItems.Count, 2);
            }
        }
    }
}