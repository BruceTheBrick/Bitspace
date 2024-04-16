namespace Bitspace.Tests.Features;

public class InitPageViewModelTests : UnitTestBase<InitPageViewModel>
{
    #region OnNavigatedToAsync

    [Fact]
    private async Task OnNavigatedToAsync_ShouldNavigateAsync()
    {
        //Arrange

        //Act
        await Sut.OnNavigatedToAsync(new NavigationParameters());

        //Assert
        Mocker.GetMock<IBaseService>().Verify(x => x.NavigationService.NavigateAsync(NavigationConstants.Homepage));
    }


    #endregion
}