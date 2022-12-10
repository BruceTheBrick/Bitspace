using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core
{
    [ExcludeFromCodeCoverage]
    public abstract class AccessibilityImplementation
    {
        public abstract void Announcement(string message);
        public abstract void NavigationAnnouncement(string message);
        public abstract bool IsScreenReaderEnabled();
    }
}