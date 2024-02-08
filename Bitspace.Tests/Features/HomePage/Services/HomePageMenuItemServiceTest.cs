using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Tests.Base;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bitspace.Tests.Features;

public class HomePageMenuItemServiceTest : UnitTestBase<HomePageMenuItemService>
{
    #region GetMenuItems

    [Fact]
    public void GetMenuItems_ShouldReturnMenuItems_WhenFeaturesAreEnabled()
    {
        // Arrange
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.IsEnabled(It.IsAny<string>())).Returns(true);

        // Act
        var items = Sut.GetMenuItems();

        // Assert
        items.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetMenuItems_ShouldNotReturnMenuItems_WhenFeaturesAreDisabled()
    {
        // Arrange
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.IsEnabled(It.IsAny<string>())).Returns(false);

        // Act
        var items = Sut.GetMenuItems();

        // Assert
        items.Should().BeNullOrEmpty();
    }
    
    #endregion
    
    #region ForceUpdateGetMenuItems

    [Fact]
    public void ForceUpdateGetMenuItems_ShouldUpdateRemoteConfig()
    {
        // Arrange
        
        // Act
        Sut.ForceUpdateGetMenuItems();

        // Assert
        Mocker.GetMock<IRemoteConfigService>().Verify(x => x.FetchAndActivate(), Times.Once);
    }

    [Fact]
    public void ForceUpdateGetMenuItems_ShouldReturnMenuItems_WhenFeaturesAreEnabled()
    {
        // Arrange
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.IsEnabled(It.IsAny<string>())).Returns(true);

        // Act
        var items = Sut.ForceUpdateGetMenuItems();

        // Assert
        items.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void ForceUpdateGetMenuItems_ShouldNotReturnMenuItems_WhenFeaturesAreDisabled()
    {
        // Arrange
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.IsEnabled(It.IsAny<string>())).Returns(false);

        // Act
        var items = Sut.ForceUpdateGetMenuItems();

        // Assert
        items.Should().BeNullOrEmpty();
    }
    
    #endregion
}