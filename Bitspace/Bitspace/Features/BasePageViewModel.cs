using System.Threading.Tasks;
using Bitspace.Services;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;

namespace Bitspace.Features
{
    [AddINotifyPropertyChangedInterface]
    public class BasePageViewModel : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
    {
        protected BasePageViewModel(IBaseService baseService)
        {
            NavigationService = baseService.NavigationService;
            AccessibilityService = baseService.AccessibilityService;
            AnalyticsService = baseService.AnalyticsService;
            AlertService = baseService.AlertService;
        }

        public bool IsBusy { get; set; }

        protected Services.INavigationService NavigationService { get; }
        protected IAccessibilityService AccessibilityService { get; }
        protected IFirebaseAnalyticsService AnalyticsService { get; }
        protected IAlertService AlertService { get; }

        public virtual void Initialize(INavigationParameters parameters)
        {
            _ = InitializeAsync(parameters);
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
