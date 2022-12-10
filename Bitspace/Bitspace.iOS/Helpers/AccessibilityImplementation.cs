using Foundation;
using UIKit;

namespace Bitspace.iOS.Helpers
{
    public class AccessibilityImplementation : Core.AccessibilityImplementation
    {
        public override void Announcement(string message)
        {
            UIAccessibility.PostNotification(UIAccessibilityPostNotification.Announcement, new NSString(message));
        }

        public override void NavigationAnnouncement(string message)
        {
            UIAccessibility.PostNotification(UIAccessibilityPostNotification.ScreenChanged, new NSString(message));
        }

        public override bool IsScreenReaderEnabled()
        {
            return UIAccessibility.IsVoiceOverRunning;
        }
    }
}