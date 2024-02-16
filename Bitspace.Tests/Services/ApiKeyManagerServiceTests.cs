namespace Bitspace.Tests.Services;

public class ApiKeyManagerServiceTests : UnitTestBase<ApiKeyManagerService>
{
    #region GetKey

    [Fact]
    public void GetKey_ShouldCallRemoteConfig()
    {
        // Arrange
        var endpoint = Faker.PickRandom<ApiEndpoints>();
        
        // Act
        Sut.GetKey(endpoint);

        // Assert
        Mocker.GetMock<IRemoteConfigService>().Verify(x => x.GetValue(endpoint.ToString()), Times.Once);
    }

    [Fact]
    public void GetKey_ShouldReturnKey_WhenRemoteConfigHasValue()
    {
        // Arrange
        var endpoint = Faker.PickRandom<ApiEndpoints>();
        var returnedKey = Faker.Hacker.Abbreviation();
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.GetValue(endpoint.ToString())).Returns(returnedKey);


        // Act
        var key = Sut.GetKey(endpoint);

        // Assert
        key.Should().Be(returnedKey);
    }

    [Fact]
    public void GetKey_ShouldReturnEmptyString_WhenRemoteConfigDoesntHaveValue()
    {
        // Arrange
        var endpoint = Faker.PickRandom<ApiEndpoints>();
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.GetValue(endpoint.ToString())).Returns(string.Empty);

        // Act
        var key = Sut.GetKey(endpoint);

        // Assert
        key.Should().BeNullOrEmpty();
    }

    #endregion
    
    #region HasKey

    [Fact]
    public void HasKey_ShouldCallRemoteConfig()
    {
        // Arrange
        var endpoint = Faker.PickRandom<ApiEndpoints>();
        
        // Act
        Sut.HasKey(endpoint);

        // Assert
        Mocker.GetMock<IRemoteConfigService>().Verify(x => x.GetValue(endpoint.ToString()), Times.Once);
    }

    [Fact]
    public void HasKey_ShouldReturnTrue_WhenRemoteConfigHasKey()
    {
        // Arrange
        var endpoint = Faker.PickRandom<ApiEndpoints>();
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.GetValue(endpoint.ToString())).Returns("some value");

        // Act
        var result = Sut.HasKey(endpoint);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void HasKey_ShouldReturnFalse_WhenRemoteConfigDoesNotHaveKey()
    {
        // Arrange
        var endpoint = Faker.PickRandom<ApiEndpoints>();
        Mocker.GetMock<IRemoteConfigService>().Setup(x => x.GetValue(endpoint.ToString())).Returns(string.Empty);
        
        // Act
        var result = Sut.HasKey(endpoint);

        // Assert
        result.Should().BeFalse();
    }
    #endregion
}