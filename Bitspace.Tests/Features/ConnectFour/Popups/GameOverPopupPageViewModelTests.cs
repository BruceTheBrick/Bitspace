using System.Threading.Tasks;
using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Resources;
using Bitspace.Tests.Base;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Features.ConnectFour.Popups
{
    public class GameOverPopupPageViewModelTests : UnitTestBase<GameOverPopupPageViewModel>
    {
        #region Initialize

        [Fact]
        private void Initialize_ShouldSetWinnerName_WhenPassed()
        {
            //Arrange
            var winnerName = "winnerName";
            var parameters = new NavigationParameters { { NavigationConstants.Winner, winnerName } };
            
            //Act
            Sut.Initialize(parameters);

            //Assert
            Sut.Winner.Should().Be(string.Format(ConnectFourRegister.CF_WINNER, winnerName));
        }
        
        #endregion

        #region PlayAgainCommand

        [Fact]
        private async Task PlayAgainCommand_ShouldGoBackAsync()
        {
            //Arrange

            //Act
            await Sut.PlayAgainCommand.ExecuteAsync();

            //Assert
            Mocker.GetMock<IBaseService>().Verify(x => x.NavigationService.GoBack(It.IsAny<INavigationParameters>()), Times.Once);
        }
        
        #endregion

        #region QuitCommand

        [Fact]
        private async Task QuitCommand_ShouldReturnToHomepage()
        {
            //Arrange

            //Act
            await Sut.QuitCommand.ExecuteAsync();

            //Assert
            Mocker.GetMock<IBaseService>().Verify(x => x.NavigationService.GoBack());

        }
        
        #endregion
    }
}