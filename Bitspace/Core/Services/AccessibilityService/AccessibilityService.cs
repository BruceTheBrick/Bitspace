using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class AccessibilityService : IAccessibilityService
{
    public bool IsScreenReaderEnabled()
    {
        return Accessibility.Current.IsScreenReaderEnabled();
    }

    public void Announcement(string message)
    {
        Accessibility.Current.Announcement(message);
    }

    public void NavigationAnnouncement(string message)
    {
        Accessibility.Current.NavigationAnnouncement(message);
    }
}