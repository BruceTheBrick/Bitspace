using System.Net;
using Bitspace.APIs;
using Bitspace.Services;
using Bitspace.Tests.Base;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bitspace.Tests.Services
{

    public class WeatherServiceTests : UnitTestBase<WeatherService>
    {
        #region GetHourlyForecast

        [Fact]
        public async Task GetHourlyForecast_ShouldRequestLocationPermissions_WhenIsExpired()
        {
            // Arrange
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);

            // Act
            await Sut.GetHourlyForecast();

            // Assert
            Mocker.GetMock<IPermissionService>()
                .Verify(x => x.RequestPermission(DevicePermissions.LOCATION), Times.Once);
        }

        [Fact]
        public async Task GetHourlyForecast_ShouldCallGetHourlyWeather_WhenIsExpired()
        {
            // Arrange
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION))
                .ReturnsAsync(true);
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);

            // Act
            await Sut.GetHourlyForecast();

            // Assert
            Mocker.GetMock<IOpenWeatherAPI>()
                .Verify(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>()), Times.Once);
        }
        
        [Fact]
        public async Task GetHourlyForecast_ShouldCallGetCurrentLocationName_WhenIsExpired()
        {
            // Arrange
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION))
                .ReturnsAsync(true);
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);

            // Act
            await Sut.GetHourlyForecast();

            // Assert
            Mocker.GetMock<IOpenWeatherAPI>()
                .Verify(x => x.GetCurrentLocationName(It.IsAny<ReverseGeocodeRequest>()), Times.Once);
        }

        [Fact]
        public async Task GetHourlyForecast_ShouldInitForecastItems_WhenHourlyForecastApiIsUnsuccessful()
        {
            //Arrange
            var response = new Response<HourlyWeatherResponse>(null, HttpStatusCode.BadRequest, HttpMethod.Get, false, string.Empty);
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION))
                .ReturnsAsync(true);
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
            Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>())).ReturnsAsync(response);

            //Act
            var hourlyForecast = await Sut.GetHourlyForecast();

            //Assert
            hourlyForecast.Should().BeEquivalentTo(new HourlyForecastViewModel());
        }
        
        [Fact]
        public async Task GetHourlyForecast_ShouldInitLocationItems_WhenCurrentLocationNameApiIsUnsuccessful()
        {
            //Arrange
            var response = new Response<ReverseGeocodeResponseItemModel[]>(null, HttpStatusCode.BadRequest, HttpMethod.Get, false, string.Empty);
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
            Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetCurrentLocationName(It.IsAny<ReverseGeocodeRequest>())).ReturnsAsync(response);

            //Act
            var hourlyForecast = await Sut.GetHourlyForecast();

            //Assert
            hourlyForecast.Location.Should().BeEquivalentTo(new LocationModel());
        }

        [Fact]
        public async Task GetHourlyForecast_ShouldDisplaySnackbar_WhenExpiredAndHttpRequestExceptionThrown()
        {
            // Arrange
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION))
                .ReturnsAsync(true);
            Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>()))
                .Throws<HttpRequestException>();

            // Act
            await Sut.GetHourlyForecast();

            // Assert
            Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetHourlyForecast_ShouldDisplaySnackbar_WhenExpiredAndExceptionThrown()
        {
            // Arrange
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION))
                .ReturnsAsync(true);
            Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetHourlyWeather(It.IsAny<HourlyForecastRequest>()))
                .Throws<Exception>();

            // Act
            await Sut.GetHourlyForecast();

            // Assert
            Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar(It.IsAny<string>()), Times.Once);
        }

        #endregion
    }
}