using Bitspace.Tests.Extensions;

namespace Bitspace.Tests.APIs;

public class DailyForecastViewModelTests
{
    #region Constructor

    [Fact]
    public void Constructor_ShouldSetDisplayText()
    {
        // Arrange
        var dateTime = DateTime.Now;
        var forecastListObjectResponse = ForecastListObjectResponseFactory.GetModels().ToList();

        // Act
        var viewModel = new DailyForecastViewModel(dateTime, forecastListObjectResponse);

        // Assert
        viewModel.DisplayDateTime.Should().Be(dateTime.ToDisplayString());
    }

    [Fact]
    public void Constructor_ShouldSetHourlyForecastItems()
    {
        // Arrange
        var dateTime = DateTime.Now;
        var forecastListObjectResponse = ForecastListObjectResponseFactory.GetModels().ToList();

        // Act
        var viewModel = new DailyForecastViewModel(dateTime, forecastListObjectResponse);
            
        // Assert
        viewModel.HourlyForecastItems.Should()
            .BeEquivalentTo(forecastListObjectResponse.ToForecastItemViewModelArray().ToList());
    }
        
    #endregion
}