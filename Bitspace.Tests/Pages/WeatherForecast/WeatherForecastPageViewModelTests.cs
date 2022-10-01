using Bitspace.Pages;
using Bitspace.Services;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories;
using Bitspace.Tests.Factories.APIs.OpenWeatherAPI;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Pages.WeatherForecast;

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
    
    #endregion
}