using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace Bitspace.Pages
{
    public class BasePageViewModel : BindableBase, IInitialize, IInitializeAsync, INavigationAware, IDestructible, IPageLifecycleAware
    {
        private string _title;

        public BasePageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool IsBusy { get; set; }

        protected INavigationService NavigationService { get; private set; }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual async Task InitializeAsync(INavigationParameters parameters)
        {
            await Task.CompletedTask;
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
