using Bitspace.APIs.OpenWeather;
using Bitspace.APIs.OpenWeather.Request_Models;
using Bitspace.Services.CurrentWeatherService;
using Bitspace.Services.PermissionService;
using Bitspace.Services.TimeoutService;
using Bitspace.Tests.Base;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bitspace.Tests.Services;

public class CurrentWeatherServiceTests : UnitTestBase<CurrentWeatherService>
{
    #region GetCurrentWeather

    [Fact]
    public async Task GetCurrentWeather_ShouldCallAPI_WhenIsExpired()
    {
        //Arrange
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
        
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>()), Times.Once);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldNotCallAPI_WhenNotIsExpired()
    {
        //Arrange
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(false);
        
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>()), Times.Never);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldReturnNull_WhenPermissionRequestReturnsFalse()
    {
        //Arrange
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(false);

        //Act
        var result = await Sut.GetCurrentWeather();

        //Assert
        result.Should().BeNull();
    }

    #endregion
}