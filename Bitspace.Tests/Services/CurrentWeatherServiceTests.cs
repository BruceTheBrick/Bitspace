using Bitspace.APIs;
using Bitspace.APIs.OpenWeather;
using Bitspace.APIs.OpenWeather.Response_Models;
using Bitspace.Services.CurrentWeatherService;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories.Responses;
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
        Sut.DateTimeLastUpdate = DateTime.Now - TimeSpan.FromMinutes(30);
        
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentWeather(), Times.Once);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldUpdateDateTimeLastUpdated_WhenIsExpired()
    {
        //Arrange
        Sut.DateTimeLastUpdate = DateTime.Now - TimeSpan.FromMinutes(30);
        var prevDateTimeUpdate = Sut.DateTimeLastUpdate;
        var apiResponse = new Response<CurrentWeatherResponse>
        {
            IsSuccess = true,
            Data = CurrentWeatherResponseFactory.GetModel()
        };
        Mocker.GetMock<IOpenWeatherAPI>().Setup(x => x.GetCurrentWeather()).ReturnsAsync(apiResponse);
        
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Sut.DateTimeLastUpdate.Should().NotBe(prevDateTimeUpdate);
        Sut.DateTimeLastUpdate.Should().BeAfter(prevDateTimeUpdate);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldNotCallAPI_WhenNotIsExpired()
    {
        //Arrange
        Sut.DateTimeLastUpdate = DateTime.Now;
        //Act
        await Sut.GetCurrentWeather();

        //Assert
        Mocker.GetMock<IOpenWeatherAPI>().Verify(x => x.GetCurrentWeather(), Times.Never);
    }

    #endregion
}