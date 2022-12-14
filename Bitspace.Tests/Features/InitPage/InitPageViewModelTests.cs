using System.Threading.Tasks;
using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Tests.Base;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Features.InitPage
{
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
}