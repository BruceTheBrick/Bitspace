namespace Bitspace.Services
{
    public interface IAccessibilityService
    {
        public bool IsScreenReaderEnabled();

        public void Announcement(string message);

        public void NavigationAnnouncement(string message);
    }
}