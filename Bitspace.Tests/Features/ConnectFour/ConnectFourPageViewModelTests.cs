using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Tests.Base;
using FluentAssertions;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Features.ConnectFour
{
    public class ConnectFourPageViewModelTests : UnitTestBase<ConnectFourPageViewModel>
    {
        #region OnNavigatedTo
        
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        private void OnNavigatedTo_ShouldUpdateUpdateButtons_WhenResetIsPassed(bool defaultValue)
        {
            //Arrange
            Sut.UpdateButtons = defaultValue;
            var parameters = new NavigationParameters { { NavigationConstants.Reset, true } };

            //Act
            Sut.OnNavigatedTo(parameters);

            //Assert
            Sut.UpdateButtons.Should().Be(!defaultValue);
        }

        [Fact]
        private void OnNavigatedTo_ShouldSetIsGameOverToFalse_WhenResetIsPassed()
        {
            //Arrange
            var parameters = new NavigationParameters { { NavigationConstants.Reset, true } };

            //Act
            Sut.OnNavigatedTo(parameters);

            //Assert
            Sut.IsGameOver.Should().BeFalse();
        }
        
        #endregion
    }
}