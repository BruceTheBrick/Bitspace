namespace Bitspace.Tests.Factories;

public static class MenuItemFactory
{
    public static MenuListItemViewModel GetViewModel()
    {
        return GetViewModels(1).First();
    }

    public static MenuListItemViewModel[] GetViewModels(int count = 5)
    {
        return new Faker<MenuListItemViewModel>()
            .CustomInstantiator(x => new MenuListItemViewModel(
                x.Image.PicsumUrl(),
                x.Person.FirstName,
                x.Image.PicsumUrl(),
                x.Company.CompanyName()))
            .Generate(count).ToArray();
    }
}