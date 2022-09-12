using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Controls
{
    public class PillViewModel
    {
        public PillViewModel()
        {
        }

        public PillViewModel(string text, string iconSource = "", bool isEnabled = true, bool isActive = false, IAsyncCommand command = null)
        {
            Text = text;
            IconSource = iconSource;
            IsEnabled = isEnabled;
            IsActive = isActive;
            Command = command;
        }

        public IAsyncCommand Command { get; }
        public string Text { get; set; }
        public string IconSource { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; }
    }
}