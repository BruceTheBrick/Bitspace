namespace Bitspace.Core;

public interface INavigationService
{
    public Task<INavigationResult> NavigateAsync(string url);
    public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters);
    public Task<INavigationResult> NavigateAsync(string url, bool useModalNavigation);
    public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters, bool useModalNavigation);
    public Task<INavigationResult> GoBack();
    public Task<INavigationResult> GoBack(INavigationParameters parameters);
}