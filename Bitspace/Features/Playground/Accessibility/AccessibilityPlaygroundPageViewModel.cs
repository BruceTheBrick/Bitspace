using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Bitspace.Core.Models;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class AccessibilityPlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    public AccessibilityPlaygroundPageViewModel(IBaseService baseService)
        : base(baseService)
    {
        InitAccessibilityActionCommands();
    }

    public IList<AccessibilityActionCommand> AccessibilityActionCommands { get; private set; }
    public int Counter { get; set; }

    private void InitAccessibilityActionCommands()
    {
        AccessibilityActionCommands = new List<AccessibilityActionCommand>();
        AccessibilityActionCommands.Add(new AccessibilityActionCommand
        {
            ActionName = "Make announcement", Command = AnnouncementCommand,
        });
        AccessibilityActionCommands.Add(new AccessibilityActionCommand
        {
            ActionName = "Decrement Counter", Command = DecrementCommand,
        });
        AccessibilityActionCommands.Add(new AccessibilityActionCommand
        {
            ActionName = "Increment Counter", Command = IncrementCommand,
        });
    }

    [RelayCommand]
    private void Announcement()
    {
        AccessibilityService.Announcement($"Counter value is currently {Counter}");
    }

    [RelayCommand]
    private void Increment()
    {
        Counter++;
    }

    [RelayCommand]
    private void Decrement()
    {
        Counter--;
    }
}