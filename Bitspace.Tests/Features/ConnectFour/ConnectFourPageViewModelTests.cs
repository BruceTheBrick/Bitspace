using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Tests.Base;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Features.ConnectFour
{
    public class ConnectFourPageViewModelTests : UnitTestBase<ConnectFourPageViewModel>
    {
        #region OnNavigatedTo

        [Fact]
        private void OnNavigatedTo_ShouldResetBoard_WhenResetIsPassed()
        {
            //Arrange
            var parameters = new NavigationParameters { { NavigationConstants.Reset, true } };

            //Act
            Sut.OnNavigatedTo(parameters);

            //Assert
            Mocker.GetMock<IBoard>().Verify(x => x.Reset(), Times.Once);
        }


        [Fact]
        private void OnNavigatedTo_ShouldUpdateUpdateButtons_WhenResetIsPassed()
        {
            //Arrange
            var initialValue = Sut.UpdateButtons;
            var parameters = new NavigationParameters { { NavigationConstants.Reset, true } };

            //Act
            Sut.OnNavigatedTo(parameters);

            //Assert
            Sut.UpdateButtons.Should().Be(!initialValue);
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

        #region UndoCommand

        [Fact]
        private void UndoCommand_ShouldCallBoardUndo()
        {
            //Arrange

            //Act
            Sut.UndoCommand.Execute(null);

            //Assert
            Mocker.GetMock<IBoard>().Verify(x => x.Undo(), Times.Once);
        }

        [Fact]
        private void UndoCommand_ShouldUpdateUpdateButtons()
        {
            //Arrange
            var initialValue = Sut.UpdateButtons;

            //Act
            Sut.UndoCommand.Execute(null);

            //Assert
            Sut.UpdateButtons.Should().Be(!initialValue);
        }
        
        #endregion
    }
}