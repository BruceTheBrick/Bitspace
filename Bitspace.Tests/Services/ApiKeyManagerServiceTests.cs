using Bitspace.APIs;
using Bitspace.Services;
using Bitspace.Tests.Base;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bitspace.Tests.Services
{
    public class ApiKeyManagerServiceTests : UnitTestBase<ApiKeyManagerService>
    {
        #region GetKey

        [Fact]
        public void GetKey_ShouldCallRemoteConfig()
        {
            // Arrange
            var faker = new Faker();
            var endpoint = faker.PickRandom<API_Endpoints>();
        
            // Act
            Sut.GetKey(endpoint);

            // Assert
            Mocker.GetMock<IRemoteConfigService>().Verify(x => x.GetValue(endpoint.ToString()), Times.Once);
        }

        [Fact]
        public void GetKey_ShouldReturnKey_WhenRemoteConfigHasValue()
        {
            // Arrange
            var faker = new Faker();
            var endpoint = faker.PickRandom<API_Endpoints>();
            var returnedKey = faker.Hacker.Abbreviation();
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
            var faker = new Faker();
            var endpoint = faker.PickRandom<API_Endpoints>();
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
            var faker = new Faker();
            var endpoint = faker.PickRandom<API_Endpoints>();
        
            // Act
            Sut.HasKey(endpoint);

            // Assert
            Mocker.GetMock<IRemoteConfigService>().Verify(x => x.GetValue(endpoint.ToString()), Times.Once);
        }

        [Fact]
        public void HasKey_ShouldReturnTrue_WhenRemoteConfigHasKey()
        {
            // Arrange
            var faker = new Faker();
            var endpoint = faker.PickRandom<API_Endpoints>();
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
            var faker = new Faker();
            var endpoint = faker.PickRandom<API_Endpoints>();
            Mocker.GetMock<IRemoteConfigService>().Setup(x => x.GetValue(endpoint.ToString())).Returns(string.Empty);
        
            // Act
            var result = Sut.HasKey(endpoint);

            // Assert
            result.Should().BeFalse();
        }
        #endregion
    }
}