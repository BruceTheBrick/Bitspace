using System;
using System.Linq;
using Bitspace.APIs;
using Bitspace.Core;
using Bitspace.Tests.Factories;
using FluentAssertions;
using Humanizer;
using Xunit;

namespace Bitspace.Tests.APIs.OpenWeather
{
    public class ForecastItemViewModelTests
    {
        #region Constructor

        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var forecastListObjectResponse = ForecastListObjectResponseFactory.GetModel();

            // Act
            var viewModel = new ForecastItemViewModel(forecastListObjectResponse);

            // Assert
            viewModel.DateTime.Should().Be(DateTime.UnixEpoch.AddSeconds(forecastListObjectResponse.DT));
            viewModel.DisplayText.Should().Be(viewModel.DateTime.ToDisplayString());
            viewModel.DisplayDateTime.Should().Be(viewModel.DateTime.ToDisplayString());
            viewModel.Temperature.Should().Be(Math.Round(forecastListObjectResponse.Main.Temperature));
            viewModel.FeelsLike.Should().Be(Math.Round(forecastListObjectResponse.Main.FeelsLike, 2));
            viewModel.RainChance.Should().Be(Math.Round(forecastListObjectResponse.Rain.RainVolume3H, 2));
            viewModel.Humidity.Should().Be(forecastListObjectResponse.Main.Humidity);
            viewModel.TemperatureMax.Should().Be(Math.Round(forecastListObjectResponse.Main.TemperatureMax, 2));
            viewModel.TemperatureMin.Should().Be(Math.Round(forecastListObjectResponse.Main.TemperatureMin, 2));
            viewModel.Description.Should().Be(forecastListObjectResponse.Weather.First().Main);
            viewModel.ExtendedDescription.Should().Be(forecastListObjectResponse.Weather.First().Description.Humanize());
            viewModel.WindSpeed.Should().Be(Math.Round(forecastListObjectResponse.Wind.Speed, 2));
            viewModel.GustSpeed.Should().Be(Math.Round(forecastListObjectResponse.Wind.Gust, 2));
        }

        #endregion
    }
}