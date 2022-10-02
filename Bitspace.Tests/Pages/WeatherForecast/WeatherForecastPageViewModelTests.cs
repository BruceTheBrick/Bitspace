using System.Security;
using Bitspace.APIs;
using Bitspace.Controls;
using Bitspace.Extensions;
using Bitspace.Pages;
using Bitspace.Services;
using Bitspace.Services.GeocodeService;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories;
using Bitspace.Tests.Factories.APIs.OpenWeatherAPI;
using Bitspace.Tests.Factories.Controls;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Pages.WeatherForecast
{
    public class WeatherForecastPageViewModelTests : UnitTestBase<WeatherForecastPageViewModel>
    {
        #region InitializeAsync

        [Fact]
        public async Task InitializeAsync_ShouldUpdateHourlyForecast()
        {
            //Arrange
            var forecastViewModel = HourlyForecastViewModelFactory.GetModel();
            Mocker.GetMock<ICurrentWeatherService>().Setup(x => x.GetHourlyForecast()).ReturnsAsync(forecastViewModel);

            //Act
            await Sut.InitializeAsync(new NavigationParameters());

            //Assert
            Sut.HourlyForecast.Should().Be(forecastViewModel);
        }

        [Fact]
        public async Task InitializeAsync_ShouldUpdateSelectedDayViewModel()
        {
            // Arrange
            var forecastViewModel = HourlyForecastViewModelFactory.GetModel();
            Mocker.GetMock<ICurrentWeatherService>().Setup(x => x.GetHourlyForecast()).ReturnsAsync(forecastViewModel);

            // Act
            await Sut.InitializeAsync(new NavigationParameters());

            // Assert
            Sut.SelectedDayViewModel.Should().Be(forecastViewModel.Days.First());
        }

        [Fact]
        public async Task InitializeAsync_ShouldCallGetCurrentLocationName()
        {
            // Arrange
            var hourlyForecastViewModel = HourlyForecastFactory.GetViewModel();
            Mocker.GetMock<ICurrentWeatherService>().Setup(x => x.GetHourlyForecast()).ReturnsAsync(hourlyForecastViewModel);

            // Act
            await Sut.InitializeAsync(new NavigationParameters());

            // Assert
            Mocker.GetMock<IGeocodeService>().Verify(x => x.GetCurrentLocationName(), Times.Once);
        }

        [Fact]
        public async Task InitializeAsync_ShouldUpdateDailyPillList()
        {
            // Arrange
            var forecastViewModel = HourlyForecastViewModelFactory.GetModel();
            Mocker.GetMock<ICurrentWeatherService>().Setup(x => x.GetHourlyForecast()).ReturnsAsync(forecastViewModel);

            // Act
            await Sut.InitializeAsync(new NavigationParameters());

            // Assert
            Assert.True(Sut.DailyPillList.All(x => forecastViewModel.Days.Any(pill => pill.DateTime.ToDisplayString() == x.Text)));
        }

        #endregion
        
        #region PillSelectedCommand

        [Fact]
        public void PillSelectedCommand_ShouldSetActivePill()
        {
            // Arrange
            var pill = PillViewModelFactory.GetModel();
            var hourlyForecastViewModel = HourlyForecastViewModelFactory.GetModel();
            Sut.ActivePill = new PillViewModel();
            pill.Text = hourlyForecastViewModel.Days.First().DateTime.ToDisplayString();
            Sut.HourlyForecast = hourlyForecastViewModel;

            // Act
            Sut.PillSelectedCommand.Execute(pill);

            // Assert
            Sut.ActivePill.Should().Be(pill);
        }
        
        #endregion
    }
}