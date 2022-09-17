using Android.Runtime;

namespace Bitspace.Services
{

    [Preserve (AllMembers = true)]
    public class DeviceAccessibilityImplementation : IAccessibilityService
    {
        public bool IsScreenReaderEnabled()
        {
            return true;
        }

        public void Announcement(string message)
        {
        }

        public void NavigationAnnouncement(string message)
        {
        }
    }
}