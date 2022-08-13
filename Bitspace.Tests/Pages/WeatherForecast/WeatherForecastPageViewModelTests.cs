using Bitspace.Pages.WeatherForecast;
using Bitspace.Services.CurrentWeatherService;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Pages.WeatherForecast;

public class WeatherForecastPageViewModelTests : UnitTestBase<WeatherForecastPageViewModel>
{
    #region InitializeAsync

    [Fact]
    public async Task InitializeAsync_ShouldUpdateWeather()
    {
        // Arrange
        var currentWeatherResponse = CurrentWeatherFactory.GetViewModel();
        Mocker.GetMock<ICurrentWeatherService>().Setup(x => x.GetCurrentWeather()).ReturnsAsync(currentWeatherResponse);

        // Act
        await Sut.InitializeAsync(It.IsAny<INavigationParameters>());

        // Assert
        Sut.Weather.Should().Be(currentWeatherResponse);
    }
    
    #endregion
}