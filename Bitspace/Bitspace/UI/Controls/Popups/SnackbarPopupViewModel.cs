using System.Threading.Tasks;
using System.Timers;
using Bitspace.Core;
using Bitspace.Features;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.UI
{
    public class SnackbarPopupViewModel : BasePageViewModel
    {
        private readonly ITimerService _timerService;
        public SnackbarPopupViewModel(ITimerService timerService, IBaseService baseService)
            : base(baseService)
        {
            _timerService = timerService;
            DismissCommand = new AsyncCommand(Dismiss);
        }

        public IAsyncCommand DismissCommand { get; }

        public Timer Timer { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }
        public Position Position { get; set; }
        public bool IsLeftIconVisible { get; set; }
        public bool IsRightIconVisible { get; set; }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            if (parameters.TryGetValue<string>(NavigationConstants.Message, out var message))
            {
                Message = message;
            }

            if (parameters.TryGetValue<string>(NavigationConstants.Icon, out var icon))
            {
                Icon = icon;
            }

            if (parameters.TryGetValue<Position>(NavigationConstants.Position, out var position))
            {
                Position = position;
            }

            SetIconVisibility();
            InitializeTimer();
        }

        public virtual void SetIconVisibility()
        {
            if (string.IsNullOrWhiteSpace(Icon))
            {
                return;
            }

            IsLeftIconVisible = Position == Position.LEFT;
            IsRightIconVisible = Position == Position.RIGHT;
        }

        public virtual void InitializeTimer()
        {
            Timer = _timerService.GetTimer(DurationConstants.SnackbarDurationMillis, TimerOnElapsed);
            Timer.Start();
        }

        private Task Dismiss()
        {
            Timer.Stop();
            return NavigationService.GoBack();
        }

        private async void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            await Dismiss();
        }
    }
}