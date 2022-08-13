﻿using Bitspace.APIs.OpenWeather;
using Bitspace.APIs.OpenWeather.Request_Models;
using Bitspace.Services.AlertService;
using Bitspace.Services.CurrentWeatherService;
using Bitspace.Services.PermissionService;
using Bitspace.Services.TimeoutService;
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
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(true);
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
        Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
        Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired()).Returns(false);
        
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentWeather(It.IsAny<CurrentWeatherRequest>()), Times.Never);
    }

    #endregion
}