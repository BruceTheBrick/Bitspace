using System.Diagnostics.CodeAnalysis;
using PropertyChanged;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    [AddINotifyPropertyChangedInterface]
    public class PillViewModel
    {
        public PillViewModel()
        {
        }

        public PillViewModel(string text, string iconSource = "", bool isEnabled = true, bool isActive = false, string id = "")
        {
            Text = text;
            IconSource = iconSource;
            IsEnabled = isEnabled;
            IsActive = isActive;
            Id = id;
        }

        public string Text { get; set; }
        public string IconSource { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; }
        public string Id { get; set; }
    }
}