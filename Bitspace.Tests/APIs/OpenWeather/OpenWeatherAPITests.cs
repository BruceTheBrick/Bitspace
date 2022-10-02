using System.Globalization;
using Bitspace.APIs;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories;
using Moq;
using Xunit;

namespace Bitspace.Tests.APIs.OpenWeather
{
    public class OpenWeatherAPITests : UnitTestBase<OpenWeatherAPI>
    {
        #region GetCurrentWeather

        [Fact]
        public async Task GetCurrentWeather_ShouldGetAsync()
        {
            // Arrange
            var request = OpenWeatherAPIRequestFactory.CurrentWeatherRequest();
            var response = HttpResponseMessageFactory.GetModel();
            Mocker.GetMock<IHttpClient>().Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(response);
            // Act
            await Sut.GetCurrentWeather(request);

            // Assert
            Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetCurrentWeather_ShouldUseRequest()
        {
            // Arrange
            var request = OpenWeatherAPIRequestFactory.CurrentWeatherRequest();
            var response = HttpResponseMessageFactory.GetModel();
            Mocker.GetMock<IHttpClient>().Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            await Sut.GetCurrentWeather(request);

            // Assert
            Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.Is<string>(z => z.Contains(request.Latitude.ToString(CultureInfo.InvariantCulture)) && z.Contains(request.Longitude.ToString(CultureInfo.InvariantCulture)))), Times.Once);
        }

        #endregion
    
        #region GetHourlyForecast

        [Fact]
        public async Task GetHourlyWeather_ShouldGetAsync()
        {
            // Arrange
            var request = OpenWeatherAPIRequestFactory.HourlyForecastRequest();
            var response = HttpResponseMessageFactory.GetModel();
            Mocker.GetMock<IHttpClient>().Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            await Sut.GetHourlyWeather(request);

            // Assert
            Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
    
        [Fact]
        public async Task GetHourlyWeather_ShouldUseRequest()
        {
            // Arrange
            var request = OpenWeatherAPIRequestFactory.HourlyForecastRequest();
            var response = HttpResponseMessageFactory.GetModel();
            Mocker.GetMock<IHttpClient>().Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            await Sut.GetHourlyWeather(request);

            // Assert
            Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.Is<string>(z => z.Contains(request.Latitude.ToString(CultureInfo.InvariantCulture)) && z.Contains(request.Longitude.ToString(CultureInfo.InvariantCulture)))), Times.Once);
        }
    
        #endregion
        
        #region GetCurrentLocationName
        
        [Fact]
        public async Task GetCurrentLocationName_ShouldGetAsync()
        {
            // Arrange
            var request = OpenWeatherAPIRequestFactory.CurrentLocationNameRequest();
            var response = HttpResponseMessageFactory.GetModel();
            Mocker.GetMock<IHttpClient>().Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            await Sut.GetCurrentLocationName(request);

            // Assert
            Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
    
        [Fact]
        public async Task GetCurrentLocationName_ShouldUseRequest()
        {
            // Arrange
            var request = OpenWeatherAPIRequestFactory.CurrentLocationNameRequest();
            var response = HttpResponseMessageFactory.GetModel();
            Mocker.GetMock<IHttpClient>().Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            await Sut.GetCurrentLocationName(request);

            // Assert
            Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.Is<string>(z => z.Contains(request.Latitude.ToString(CultureInfo.InvariantCulture)) && z.Contains(request.Longitude.ToString(CultureInfo.InvariantCulture)))), Times.Once);
        }
        
        #endregion
    }
}