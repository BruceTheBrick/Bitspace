using System;
using System.Linq;
using Bitspace.Extensions;
using Humanizer;

namespace Bitspace.APIs
{
    public class ForecastItemViewModel
    {
        public ForecastItemViewModel()
        {
        }

        public ForecastItemViewModel(ForecastListObjectResponse response)
        {
            DateTime = InitDateTime(response.DT);
            DisplayText = DateTime.ToDisplayString();
            DisplayDateTime = DateTime.ToDisplayString();
            DisplayTime = DateTime.ToShortTimeString();
            Temperature = Math.Round(response.Main.Temperature);
            FeelsLike = Math.Round(response.Main.FeelsLike, 2);
            RainChance = GetRainChance(response.Rain?.RainVolume3H);
            Humidity = response.Main.Humidity;
            TemperatureMax = Math.Round(response.Main.TemperatureMax, 2);
            TemperatureMin = Math.Round(response.Main.TemperatureMin, 2);
            Description = response.Weather.First().Main;
            ExtendedDescription = response.Weather.First().Description.Humanize();
            WindSpeed = Math.Round(response.Wind.Speed, 2);
            GustSpeed = Math.Round(response.Wind.Gust, 2);
        }

        public DateTime DateTime { get; }
        public string DisplayText { get; }
        public string DisplayDateTime { get; set; }
        public string DisplayTime { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; }
        public double RainChance { get; set; }
        public double Humidity { get; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }
        public string Description { get; }
        public string ExtendedDescription { get; set; }
        public double WindSpeed { get; }
        public double GustSpeed { get; }

        private DateTime InitDateTime(long utcTime)
        {
            return DateTime.UnixEpoch.AddSeconds(utcTime);
        }

        private double GetRainChance(double? rainChance)
        {
            return rainChance == null ? 0.0 : Math.Round(rainChance.Value, 2);
        }
    }
}