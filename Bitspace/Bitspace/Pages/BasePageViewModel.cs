using System.Threading.Tasks;
using Bitspace.Registers;
using Bitspace.Services;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using INavigationService = Bitspace.Services.NavigationService.INavigationService;

namespace Bitspace.Pages
{
    public class BasePageViewModel : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
    {
        private string _title;

        protected BasePageViewModel(IBaseService baseService)
        {
            NavigationService = baseService.NavigationService;
            AccessibilityService = baseService.AccessibilityService;
            AnalyticsService = baseService.AnalyticsService;
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool IsBusy { get; set; }

        protected INavigationService NavigationService { get; }
        protected IAccessibilityService AccessibilityService { get; }
        protected IFirebaseAnalyticsService AnalyticsService { get; }

        public virtual void Initialize(INavigationParameters parameters)
        {
            InitializeAsync(parameters).ConfigureAwait(false);
        }

        public virtual Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            AnalyticsService.LogEvent(AnalyticsRegister.SCREEN_VIEW, AnalyticsRegister.ID, _title);
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
