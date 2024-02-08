namespace Bitspace.Core;

public class NavigationService : INavigationService
{
    private readonly Prism.Navigation.INavigationService _navigationService;

    public NavigationService(Prism.Navigation.INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public Task<INavigationResult> NavigateAsync(string url)
    {
        return _navigationService.NavigateAsync(url);
    }

    public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters)
    {
        return _navigationService.NavigateAsync(url, parameters);
    }

    public Task<INavigationResult> NavigateAsync(string url, bool useModalNavigation)
    {
        var parameters = AddModalParameter(null, useModalNavigation);
        return _navigationService.NavigateAsync(url, parameters);
    }

    public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters, bool useModalNavigation)
    {
        parameters = AddModalParameter(parameters, useModalNavigation);
        return _navigationService.NavigateAsync(url, parameters);
    }

    public Task<INavigationResult> GoBack()
    {
        return _navigationService.GoBackAsync();
    }

    public Task<INavigationResult> GoBack(INavigationParameters parameters)
    {
        return _navigationService.GoBackAsync(parameters);
    }

    private INavigationParameters AddModalParameter(INavigationParameters parameters, bool useModal)
    {
        parameters ??= new NavigationParameters();
        parameters.Add(KnownNavigationParameters.UseModalNavigation, useModal);
        return parameters;
    }
}