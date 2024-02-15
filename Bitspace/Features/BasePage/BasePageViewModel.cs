using AsyncAwaitBestPractices;
using Bitspace.Core;
using Bitspace.Resources.Registers.Analytics;
using PropertyChanged;
using INavigationService = Bitspace.Core.INavigationService;

namespace Bitspace.Features;

[AddINotifyPropertyChangedInterface]
public class BasePageViewModel : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
{
    public BasePageViewModel(IBaseService baseService)
    {
        NavigationService = baseService.NavigationService;
        AccessibilityService = baseService.AccessibilityService;
        AnalyticsService = baseService.AnalyticsService;
        AlertService = baseService.AlertService;
    }

    public bool IsBusy { get; set; }
    protected INavigationService NavigationService { get; }
    protected IAccessibilityService AccessibilityService { get; }
    protected IAnalyticsService AnalyticsService { get; }
    protected IAlertService AlertService { get; }

    public virtual void Initialize(INavigationParameters parameters)
    {
        InitializeAsync(parameters).SafeFireAndForget();
        AnalyticsService.LogEvent(AnalyticsRegister.SCREEN_VIEW, AnalyticsRegister.ID, GetPageName());
    }

    public virtual Task InitializeAsync(INavigationParameters parameters)
    {
        return Task.CompletedTask;
    }

    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    {
        OnNavigatedFromAsync(parameters).SafeFireAndForget();
    }

    public virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
    {
        return Task.CompletedTask;
    }

    public virtual void OnNavigatedTo(INavigationParameters parameters)
    {
        OnNavigatedToAsync(parameters).SafeFireAndForget();
    }

    public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
    {
        return Task.CompletedTask;
    }

    public virtual void Destroy()
    {
    }

    public virtual void OnAppearing()
    {
    }

    public virtual void OnDisappearing()
    {
    }

    private string GetPageName()
    {
        return this.GetType().Name.Replace("ViewModel", string.Empty);
    }
}