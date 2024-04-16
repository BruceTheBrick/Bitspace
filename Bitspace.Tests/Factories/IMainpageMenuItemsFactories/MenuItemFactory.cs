using Bitspace.Pages.Mainpage.Models;
using Bogus;

namespace Bitspace.Tests.Factories.IMainpageMenuItemsFactories;

public static class MenuItemFactory
{
    public static MenuListItemViewModel GetViewModel()
    {
        return GetViewModels(1).First();
    }

    public static MenuListItemViewModel[] GetViewModels(int count = 5)
    {
        return new Faker<MenuListItemViewModel>()
            .RuleFor(x => x.Icon, f => f.Image.PicsumUrl())
            .RuleFor(x => x.Text, f => f.Name.FirstName())
            .RuleFor(x => x.ActionIcon, f => f.Image.PicsumUrl())
            .RuleFor(x => x.NavigationConstant, f => f.Address.Country())
            .Generate(count).ToArray();
    }
}