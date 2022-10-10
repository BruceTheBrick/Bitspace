using System.Threading.Tasks;
using Bitspace.Services;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace Bitspace.Features
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

        protected Services.INavigationService NavigationService { get; }
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
