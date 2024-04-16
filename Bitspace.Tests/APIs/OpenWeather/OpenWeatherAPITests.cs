using System.Globalization;

namespace Bitspace.Tests.APIs;

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
        Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.IsAny<Uri>()));
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
        Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.Is<Uri>(z => z.Query.Contains(request.Latitude.ToString(CultureInfo.InvariantCulture)) && z.Query.Contains(request.Longitude.ToString(CultureInfo.InvariantCulture)))));
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
        Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.IsAny<Uri>()));
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
        Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.Is<Uri>(z => z.Query.Contains(request.Latitude.ToString(CultureInfo.InvariantCulture)) && z.Query.Contains(request.Longitude.ToString(CultureInfo.InvariantCulture)))));
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
        Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.IsAny<Uri>()));
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
        Mocker.GetMock<IHttpClient>().Verify(x => x.GetAsync(It.Is<Uri>(z => z.Query.Contains(request.Latitude.ToString(CultureInfo.InvariantCulture)) && z.Query.Contains(request.Longitude.ToString(CultureInfo.InvariantCulture)))));
    }
        
    #endregion
}