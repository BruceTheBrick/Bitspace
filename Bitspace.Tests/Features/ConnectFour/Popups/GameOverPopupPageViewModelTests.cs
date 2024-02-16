namespace Bitspace.Tests.Features;

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
        Sut.Winner.Should().Be(string.Format(ConnectFourRegister.Winner, winnerName));
    }
        
    #endregion

    #region PlayAgainCommand

    [Fact]
    private async Task PlayAgainCommand_ShouldGoBackAsync()
    {
        //Arrange

        //Act
        await Sut.PlayAgainCommand.ExecuteAsync(null);

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
        await Sut.QuitCommand.ExecuteAsync(null);

        //Assert
        Mocker.GetMock<IBaseService>().Verify(x => x.NavigationService.GoBack());

    }
        
    #endregion
}