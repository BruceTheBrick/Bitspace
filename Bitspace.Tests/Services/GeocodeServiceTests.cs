using Bitspace.APIs;
using Bitspace.Services;
using Bitspace.Tests.Base;
using Moq;
using Xunit;

namespace Bitspace.Tests.Services
{

    public class GeocodeServiceTests : UnitTestBase<GeocodeService>
    {
        #region GetCurrentLocation

        [Fact]
        public async Task GetCurrentLocationName_ShouldRequestLocationPermission_WhenIsExpired()
        {
            // Arrange
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);

            // Act
            await Sut.GetCurrentLocationName();

            // Assert
            Mocker.GetMock<IPermissionService>().Verify(x => x.RequestPermission(DevicePermissions.LOCATION), Times.Once);
        }

        [Fact]
        public async Task GetCurrentLocationName_ShouldCallApi_WhenIsExpired()
        {
            // Arrange
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(DevicePermissions.LOCATION)).ReturnsAsync(true);

            // Act
            await Sut.GetCurrentLocationName();

            // Assert
            Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentLocationName(It.IsAny<ReverseGeocodeRequest>()), Times.Once);
        }

        [Fact]
        public async Task GetCurrentLocationName_ShouldShowSnackbar_WhenHttpRequestExceptionThrown()
        {
            // Arrange
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(It.IsAny<DevicePermissions>())).Throws(new HttpRequestException());

            // Act
            await Sut.GetCurrentLocationName();

            // Assert
            Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar("Uh oh, looks like we timed out! Please try again later.."), Times.Once);
        }

        [Fact]
        public async Task GetCurrentLocationName_ShouldShowSnackbar_WhenExceptionIsThrown()
        {
            // Arrange
            var exception = new Exception();
            Mocker.GetMock<ITimeoutService>().Setup(x => x.IsExpired(It.IsAny<DateTime>())).Returns(true);
            Mocker.GetMock<IPermissionService>().Setup(x => x.RequestPermission(It.IsAny<DevicePermissions>())).Throws(exception);

            // Act
            await Sut.GetCurrentLocationName();

            // Assert
            Mocker.GetMock<IAlertService>().Verify(x => x.Snackbar(exception.Message), Times.Once);
        }
        
        #endregion
    }
}