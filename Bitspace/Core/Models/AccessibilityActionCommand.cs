using System.Windows.Input;

namespace Bitspace.Core;

public class AccessibilityActionCommand
{
    public string ActionName { get; set; }
    public ICommand Command { get; set; }
}