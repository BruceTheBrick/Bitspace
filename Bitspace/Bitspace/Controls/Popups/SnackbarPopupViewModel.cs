using System.Timers;
using Bitspace.Core;
using Bitspace.Features;
using Bitspace.Services;
using Prism.Navigation;

namespace Bitspace.Controls
{
    public class SnackbarPopupViewModel : BasePageViewModel
    {
        public SnackbarPopupViewModel(IBaseService baseService)
            : base(baseService)
        {
        }

        public string Message { get; set; }
        public string Icon { get; set; }
        public Position Position { get; set; }
        public bool IsLeftIconVisible { get; set; }
        public bool IsRightIconVisible { get; set; }

        public override void Initialize(INavigationParameters parameters)
        {
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

            base.Initialize(parameters);
            var timer = new Timer(6000);
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
        }

        private async void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            await NavigationService.GoBack();
        }

        private void SetIconVisibility()
        {
            if (string.IsNullOrWhiteSpace(Icon))
            {
                return;
            }

            IsLeftIconVisible = Position == Position.LEFT;
        }
    }
}