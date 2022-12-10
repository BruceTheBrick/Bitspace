using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Bitspace.Core;
using Bitspace.Core.Models;
using Xamarin.Forms;

namespace Bitspace.Features
{
    [ExcludeFromCodeCoverage]
    public class AccessibilityPlaygroundPageViewModel : BasePageViewModel
    {
        public AccessibilityPlaygroundPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            AnnouncementCommand = new Command(Announcement);
            IncrementCommand = new Command(Increment);
            DecrementCommand = new Command(Decrement);
            InitAccessibilityActionCommands();
        }

        public IList<AccessibilityActionCommand> AccessibilityActionCommands { get; set; }
        public ICommand AnnouncementCommand { get; }
        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }
        public int Counter { get; set; }

        private void InitAccessibilityActionCommands()
        {
            AccessibilityActionCommands = new List<AccessibilityActionCommand>();
            AccessibilityActionCommands.Add(new AccessibilityActionCommand
            {
                ActionName = "Make announcement",
                Command = AnnouncementCommand,
            });
            AccessibilityActionCommands.Add(new AccessibilityActionCommand
            {
                ActionName = "Decrement Counter",
                Command = DecrementCommand,
            });
            AccessibilityActionCommands.Add(new AccessibilityActionCommand
            {
                ActionName = "Increment Counter",
                Command = IncrementCommand,
            });
        }

        private void Announcement()
        {
            AccessibilityService.Announcement($"Counter value is currently {Counter}");
        }

        private void Increment()
        {
            Counter++;
            // Announcement();
        }

        private void Decrement()
        {
            Counter--;
            // Announcement();
        }
    }
}