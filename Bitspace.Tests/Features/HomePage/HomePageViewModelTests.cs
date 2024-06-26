﻿using System.Collections.ObjectModel;

namespace Bitspace.Tests.Features;

public class MainPageViewModelTests : UnitTestBase<HomePageViewModel>
{
    #region Initialize

    [Fact]
    public void Initialize_ShouldSetMenuItems()
    {
        //Arrange
        var menuItems = new ObservableCollection<MenuListItemViewModel>(MenuItemFactory.GetViewModels());
        Mocker.GetMock<IHomePageMenuItems>().Setup(x => x.GetMenuItems()).Returns(menuItems);

        //Act
        Sut.Initialize(It.IsAny<INavigationParameters>());

        //Assert
        Mocker.GetMock<IHomePageMenuItems>().Verify(x => x.GetMenuItems());
        Sut.MenuItems.Should().Equal(menuItems);
    }
    
    #endregion

    #region ItemSelectedCommand

    [Fact]
    public void ItemSelectedCommand_ShouldNavigateAsync_WhenNavigationConstantNotNullOrEmpty()
    {
        //Arrange
        var menuItem = MenuItemFactory.GetViewModel();

        //Act
        Sut.ItemSelectedCommand.Execute(menuItem);

        //Assert
        Mocker.GetMock<IBaseService>().Verify(x => x.NavigationService.NavigateAsync(menuItem.NavigationConstant));
    }

    #endregion

    #region RefreshMenuItemsCommand

    [Fact]
    public void RefreshMenuItemsCommand_ShouldUpdateMenuItems()
    {
        //Arrange
        var menuItems = new ObservableCollection<MenuListItemViewModel>(MenuItemFactory.GetViewModels());
        Mocker.GetMock<IHomePageMenuItems>().Setup(x => x.ForceUpdateGetMenuItems()).Returns(menuItems);

        //Act
        Sut.RefreshMenuItemsCommand.Execute(null);

        //Assert
        Mocker.GetMock<IHomePageMenuItems>().Verify(x => x.ForceUpdateGetMenuItems());
        Sut.MenuItems.Should().Equal(menuItems);
    }
    #endregion
}