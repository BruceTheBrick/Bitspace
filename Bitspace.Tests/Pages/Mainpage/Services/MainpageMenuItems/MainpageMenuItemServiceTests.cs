using Bitspace.Pages.Mainpage.Services.MainpageMenuItems;
using Bitspace.Services.FirebaseRemoteConfig;
using Bitspace.Tests.Base;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bitspace.Tests.Pages.Mainpage.Services.MainpageMenuItems
{
    public class MainpageMenuItemServiceTests : UnitTestBase<MainpageMenuItemService>
    {
        #region GetMenuItems
        [Fact]
        public async Task GetMenuItems_ShouldReturnMenuItems()
        {
            //Arrange
            Mocker.GetMock<IFirebaseRemoteConfig>().Setup(x => x.IsEnabled(It.IsAny<string>())).ReturnsAsync(true);
            
            //Act
            var items = await Sut.GetMenuItems();
            
            //Assert
            items.Should().NotBeNullOrEmpty();
        }
        #endregion


    }
}
