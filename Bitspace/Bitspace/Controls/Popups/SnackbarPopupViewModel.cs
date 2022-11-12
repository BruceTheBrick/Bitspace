using System.Threading.Tasks;
using System.Timers;
using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Services;
using Bitspace.Services.TimerService;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Controls
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
            _timerService.Timer(6000, TimerOnElapsed).Start();
        }

        private Task Dismiss()
        {
            return NavigationService.GoBack();
        }

        private async void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            await Dismiss();
        }

        private void SetIconVisibility()
        {
            if (string.IsNullOrWhiteSpace(Icon))
            {
                return;
            }

            IsLeftIconVisible = Position == Position.LEFT;
            IsRightIconVisible = Position == Position.RIGHT;
        }
    }
}