using Bitspace.APIs;
using Bitspace.Tests.Factories;
using FluentAssertions;
using Xunit;

namespace Bitspace.Tests.APIs.OpenWeather
{

    public class HourlyForecastViewModelTests
    {
        
        #region Constructor

        [Fact]
        public void Constructor_ShouldInitForecastItems()
        {
            //Arrange
            var hourlyWeatherResponse = HourlyForecastFactory.GetModel();
            
            //Act
            var viewModel = new HourlyForecastViewModel(hourlyWeatherResponse);

            //Assert
            viewModel.ForecastItems.Count.Should().Be(hourlyWeatherResponse.List.Length);
        }

        [Fact]
        public void Constructor_ShouldInitDays()
        {
            // Arrange
            var hourlyWeatherResponse = HourlyForecastFactory.GetModel();

            // Act
            var viewModel = new HourlyForecastViewModel(hourlyWeatherResponse);

            // Assert
            viewModel.Days.Should().OnlyHaveUniqueItems();
        }
        
        #endregion
    }
}