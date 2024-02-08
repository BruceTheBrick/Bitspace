using System.Linq;
using Bitspace.APIs;
using Bitspace.Tests.Factories;
using FluentAssertions;
using Xunit;

namespace Bitspace.Tests.APIs.OpenWeather;

public class CurrentWeatherViewModelTests
{
    #region Constructor

    [Fact]
    public void Constructor_ShouldSetProperties()
    {
        // Arrange
        var currentWeatherResponse = CurrentWeatherFactory.GetModel();

        // Act
        var viewModel = new CurrentWeatherViewModel(currentWeatherResponse);

        // Assert
        viewModel.Suburb.Should().Be(currentWeatherResponse.Name);
        viewModel.Temperature.Should().Be(currentWeatherResponse.Main.Temperature);
        viewModel.FeelsLike.Should().Be(currentWeatherResponse.Main.FeelsLike);
        viewModel.Humidity.Should().Be(currentWeatherResponse.Main.Humidity);
        viewModel.Pressure.Should().Be(currentWeatherResponse.Main.Pressure);
        viewModel.WindSpeed.Should().Be(currentWeatherResponse.Wind.Speed);
        viewModel.Description.Should().Be(currentWeatherResponse.Weather.First().Description);
    }

    [Fact]
    public void Constructor_ShouldSetDescriptionList()
    {
        // Arrange
        var currentWeatherResponse = CurrentWeatherFactory.GetModel();
        var descriptionList = currentWeatherResponse.Weather.Select(x => x.Description.ToUpper()).ToList();

        // Act
        var viewModel = new CurrentWeatherViewModel(currentWeatherResponse);

        // Assert
        viewModel.DescriptionList.Should().BeEquivalentTo(descriptionList);
    }

    [Fact]
    public void Constructor_ShouldSetIconUrl()
    {
        // Arrange
        var currentWeatherResponse = CurrentWeatherFactory.GetModel();
        var icon = currentWeatherResponse.Weather.First().Icon;

        // Act
        var viewModel = new CurrentWeatherViewModel(currentWeatherResponse);

        // Assert
        viewModel.IconUrl.Should().Be($"http://openweathermap.org/img/wn/{icon}@4x.png");
    }
    
    #endregion
}