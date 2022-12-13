using System.Threading.Tasks;
using Bitspace.Core;
using Bitspace.Resources;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using INavigationService = Bitspace.Core.INavigationService;

namespace Bitspace.Features
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BasePageViewModel : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
    {
        protected BasePageViewModel(IBaseService baseService)
        {
            NavigationService = baseService.NavigationService;
            AccessibilityService = baseService.AccessibilityService;
            AnalyticsService = baseService.AnalyticsService;
            AlertService = baseService.AlertService;
        }

        public bool IsBusy { get; set; }
        protected abstract string PageName { get; set; }

        protected INavigationService NavigationService { get; }
        protected IAccessibilityService AccessibilityService { get; }
        protected IAnalyticsService AnalyticsService { get; }
        protected IAlertService AlertService { get; }

        public virtual void Initialize(INavigationParameters parameters)
        {
            _ = InitializeAsync(parameters);
            AnalyticsService.LogEvent(AnalyticsRegister.SCREEN_VIEW, AnalyticsRegister.ID, PageName);
        }

        public virtual Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            _ = OnNavigatedFromAsync(parameters);
        }

        public virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            _ = OnNavigatedToAsync(parameters);
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
    }
}
