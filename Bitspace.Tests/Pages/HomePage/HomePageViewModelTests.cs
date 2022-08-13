﻿using System.Collections.ObjectModel;
using Bitspace.Pages.HomePage.Services;
using Bitspace.Pages.Mainpage;
using Bitspace.Pages.Mainpage.Models;
using Bitspace.Tests.Base;
using Bitspace.Tests.Factories.Pages.Mainpage.Services;
using FluentAssertions;
using Moq;
using Prism.Navigation;
using Xunit;

namespace Bitspace.Tests.Pages.HomePage;

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
        Mocker.GetMock<IHomePageMenuItems>().Verify(x => x.GetMenuItems(), Times.Once);
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
        Mocker.GetMock<INavigationService>().Verify(x => x.NavigateAsync(menuItem.NavigationConstant), Times.Once);
    }

    [Fact]
    public void ItemSelectedCommand_ShouldNotNavigateAsync_WhenNavigationConstantIsEmpty()
    {
        //Arrange
        var menuItem = MenuItemFactory.GetViewModel();
        menuItem.NavigationConstant = string.Empty;

        //Act
        Sut.ItemSelectedCommand.Execute(menuItem);

        //Assert
        Mocker.GetMock<INavigationService>().Verify(x => x.NavigateAsync(It.IsAny<string>()), Times.Never);
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
        Mocker.GetMock<IHomePageMenuItems>().Verify(x => x.ForceUpdateGetMenuItems(), Times.Once);
        Sut.MenuItems.Should().Equal(menuItems);
    }
    #endregion
}