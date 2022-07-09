using System.Collections.ObjectModel;
using Bitspace.Pages.Mainpage;
using Bitspace.Pages.Mainpage.Models;
using Bitspace.Pages.Mainpage.Services.MainpageMenuItems;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories.IMainpageMenuItemsFactories;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Pages.Mainpage;

public class MainpageViewModelTests : UnitTestBase<MainPageViewModel>
{
    #region InitializeAsync

    [Fact]
    public async Task InitializeAsync_ShouldInitializeMenuItems()
    {
        //Arrange
        var menuItems = new ObservableCollection<MenuListItemViewModel>(MenuItemFactory.GetViewModels());
        Mocker.GetMock<IMainpageMenuItems>().Setup(x => x.GetMenuItems()).ReturnsAsync(menuItems);

        //Act
        await Sut.InitializeAsync(It.IsAny<INavigationParameters>());

        //Assert
        Sut.MenuItems.Should().Equal(menuItems);
    }
    #endregion
}