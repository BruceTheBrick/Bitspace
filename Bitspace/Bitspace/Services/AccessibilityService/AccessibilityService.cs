using System.Diagnostics.CodeAnalysis;
using Bitspace.Helpers;

namespace Bitspace.Services
{
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
}