using Bitspace.APIs;
using Bitspace.Tests.Factories;
using FluentAssertions;
using Humanizer;
using Xunit;

namespace Bitspace.Tests.APIs.OpenWeather
{
    public class DayViewModelTests
    {
        #region AddForecastItem

        [Fact]
        public void AddForecastItem_ShouldUpdateProperties()
        {
            // Arrange
            var forecastItem = ForecastItemViewModelFactory.GetModel();
            var viewModel = new DayViewModel();
            
            // Act
            viewModel.AddForecastItem(forecastItem);

            // Assert
            viewModel.Temperature.Should().Be(Math.Round(forecastItem.Temperature));
            viewModel.WindSpeed.Should().Be(Math.Round(forecastItem.WindSpeed));
            viewModel.Humidity.Should().Be(Math.Round(forecastItem.Humidity));
            viewModel.RainChance.Should().Be(Math.Round(forecastItem.RainChance));
        }

        [Fact]
        public void AddForecastItem_ShouldCalculateAverages()
        {
            // Arrange
            var forecastItem = ForecastItemViewModelFactory.GetModel();
            var viewModel = new DayViewModel();

            // Act
            viewModel.AddForecastItem(forecastItem);
            viewModel.AddForecastItem(forecastItem);

            // Assert
            viewModel.Temperature.Should().Be(Math.Round(forecastItem.Temperature * 2 / viewModel.ForecastItems.Count));
            viewModel.WindSpeed.Should().Be(Math.Round(forecastItem.WindSpeed * 2 / viewModel.ForecastItems.Count));
            viewModel.Humidity.Should().Be(Math.Round(forecastItem.Humidity * 2 / viewModel.ForecastItems.Count));
            viewModel.RainChance.Should().Be(Math.Round(forecastItem.RainChance * 2 / viewModel.ForecastItems.Count));
        }

        [Fact]
        public void AddForecastItem_ShouldSetDescription()
        {
            // Arrange
            var forecastItem = ForecastItemViewModelFactory.GetModel();
            var viewModel = new DayViewModel();
            
            // Act
            viewModel.AddForecastItem(forecastItem);

            // Assert
            viewModel.Description.Should().Be(forecastItem.Description.Humanize());
        }

        #endregion
    }
}