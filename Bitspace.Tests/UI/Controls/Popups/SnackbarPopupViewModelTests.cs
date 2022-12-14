using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Timers;
using Bitspace.Core;
using Bitspace.Tests.Base;
using Bitspace.UI;
using DryIoc;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.UI.Controls.Popups
{
    public class SnackbarPopupViewModelTests : UnitTestBase<SnackbarPopupViewModel>
    {
        #region Initialize

        [Fact]
        private void Initialize_ShouldSetMessage_WhenMessageIsPassed()
        {
            //Arrange
            var message = "my message";
            var parameters = new NavigationParameters { { NavigationConstants.Message, message } };
            
            //Act
            Sut.Initialize(parameters);

            //Assert
            Sut.Message.Should().Be(message);
        }

        [Fact]
        private void Initialize_ShouldSetIcon_WhenIconIsPassed()
        {
            //Arrange
            var icon = "ic_chevron_right";
            var parameters = new NavigationParameters { { NavigationConstants.Icon, icon } };
            
            //Act
            Sut.Initialize(parameters);

            //Assert
            Sut.Icon.Should().Be(icon);
        }

        [Fact]
        private void Initialize_ShouldSetPosition_WhenPositionIsPassed()
        {
            //Arrange
            var position = Position.TOP;
            var parameters = new NavigationParameters { { NavigationConstants.Position, position } };
            
            //Act
            Sut.Initialize(parameters);

            //Assert
            Sut.Position.Should().Be(position);
        }

        [Fact]
        private void Initialize_ShouldCallSetIconVisibility()
        {
            //Arrange

            //Act
            SutMock.Object.Initialize(new NavigationParameters());

            //Assert
            SutMock.Verify(x => x.SetIconVisibility());
        }

        [Fact]
        private void Initialize_ShouldCallInitializeTimer()
        {
            //Arrange

            //Act
            SutMock.Object.Initialize(new NavigationParameters());

            //Assert
            SutMock.Verify(x => x.InitializeTimer());
        }

        #endregion

        #region SetIconVisibility

        [Fact]
        private void SetIconVisibility_ShouldDoNothing_WhenIconIsNullOrWhitespace()
        {
            //Arrange

            //Act
            Sut.SetIconVisibility();

            //Assert
            Sut.IsLeftIconVisible.Should().BeFalse();
            Sut.IsRightIconVisible.Should().BeFalse();
        }

        [Fact]
        private void SetIconVisibility_ShouldSetIsLeftIconVisibleToTrue_WhenIconIsNotNullOrEmptyAndPositionIsLeft()
        {
            //Arrange
            Sut.Icon = "ic_chevron";
            Sut.Position = Position.LEFT;

            //Act
            Sut.SetIconVisibility();

            //Assert
            Sut.IsLeftIconVisible.Should().BeTrue();
        }

        [Fact]
        private void SetIconVisibility_ShouldSetIsRightIconVisibleToTrue_WhenIconIsNotNullOrEmptyAndPositionIsRight()
        {
            //Arrange
            Sut.Icon = "ic_chevron";
            Sut.Position = Position.RIGHT;
            
            //Act
            Sut.SetIconVisibility();

            //Assert
            Sut.IsRightIconVisible.Should().BeTrue();
        }

        #endregion

        #region InitializeTimer

        [Fact]
        private void InitializeTimer_ShouldCallTimerService()
        {
            //Arrange

            //Act
            Sut.InitializeTimer();

            //Assert
            Mocker.GetMock<ITimerService>().Verify(x => x.GetTimer(DurationConstants.SnackbarDurationMillis, It.IsAny<ElapsedEventHandler>()));
        }
        
        #endregion

        #region DismissCommand

        [Fact]
        private async Task DismissCommand_Should()
        {
            //Arrange
            Sut.Timer = new Timer();

            //Act
            await Sut.DismissCommand.ExecuteAsync();

            //Assert
            Mocker.GetMock<IBaseService>().Verify(x => x.NavigationService.GoBack());
        }

        #endregion
    }
}