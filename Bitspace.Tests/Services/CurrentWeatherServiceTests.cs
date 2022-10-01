using Bitspace.APIs;
using Bitspace.Services;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories;
using Moq;
using Xunit;

namespace Bitspace.Tests.Services;

public class CurrentWeatherServiceTests : UnitTestBase<CurrentWeatherService>
{
    #region GetCurrentWeather

    [Fact]
    public async Task GetCurrentWeather_ShouldRequestLocationPermission_WhenIsExpired()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);

        // Act
        await Sut.GetCurrentWeather();

        // Assert
        Mocker.GetMock<IPermissionService>().Verify(x => x.RequestPermission(DevicePermissions.LOCATION), Times.Once);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldCallAPI_WhenIsExpired()
    {
        //Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>()), Times.Once);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldCallUpdate_WhenAPIIsSuccessful()
    {
        // Arrange
        var data = CurrentWeatherFactory.GetModel();
        var response = ResponseFactory.GetSuccessfulResponse(data);
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>())).ReturnsAsync(response);
        
        // Act
        await Sut.GetCurrentWeather();
        
        //Assert
        Mocker.GetMock<ITimeoutService>().Verify(x => x.Update(), Times.Once);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldDisplaySnackbar_WhenExpiredAndHttpRequestExceptionThrown()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>())).Throws<HttpRequestException>();

        // Act
        await Sut.GetCurrentWeather();

        // Assert
        Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar(It.IsAny<string>()), Times.Once);
    }
    
    [Fact]
    public async Task GetCurrentWeather_ShouldDisplaySnackbar_WhenExpiredAndExceptionThrown()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>())).Throws<Exception>();

        // Act
        await Sut.GetCurrentWeather();

        // Assert
        Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldNotCallAPI_WhenNotIsExpired()
    {
        //Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(false);
        
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>()), Times.Never);
    }

    #endregion

    #region GetHourlyForecast

    [Fact]
    public async Task GetHourlyForecast_ShouldRequestLocationPermissions_WhenIsExpired()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);

        // Act
        await Sut.GetHourlyForecast();

        // Assert
        Mocker.GetMock<IPermissionService>().Verify(x => x.RequestPermission(DevicePermissions.LOCATION), Times.Once);
    }

    [Fact]
    public async Task GetHourlyForecast_ShouldCallAPI_WhenIsExpired()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);

        // Act
        await Sut.GetHourlyForecast();

        // Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>()), Times.Once);
    }

    [Fact]
    public async Task GetHourlyForecast_ShouldCallUpdate_WhenAPIIsSuccessful()
    {
        // Arrange
        var data = HourlyForecastFactory.GetModel();
        var response = ResponseFactory.GetSuccessfulResponse(data);
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>())).ReturnsAsync(response);

        // Act
        await Sut.GetHourlyForecast();

        // Assert
        Mocker.GetMock<ITimeoutService>().Verify(x => x.Update(), Times.Once);
    }

    [Fact]
    public async Task GetHourlyForecast_ShouldDisplaySnackbar_WhenExpiredAndHttpRequestExceptionThrown()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>())).Throws<HttpRequestException>();

        // Act
        await Sut.GetHourlyForecast();

        // Assert
        Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task GetHourlyForecast_ShouldDisplaySnackbar_WhenExpiredAndExceptionThrown()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>())).Throws<Exception>();

        // Act
        await Sut.GetHourlyForecast();

        // Assert
        Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task GetHourlyForecast_ShouldNotCallAPI_WhenIsNotExpired()
    {
        // Arrange
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(false);

        // Act
        await Sut.GetHourlyForecast();

        // Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>()), Times.Never);
    }

    #endregion
}