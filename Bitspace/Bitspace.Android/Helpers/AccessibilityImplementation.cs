using Android.AccessibilityServices;
using Android.App;
using Android.Views.Accessibility;

namespace Bitspace.Droid.Helpers
{
    public class AccessibilityImplementation : Bitspace.Helpers.AccessibilityImplementation
    {
        private readonly AccessibilityManager _accessibilityManager;
        public AccessibilityImplementation()
        {
            _accessibilityManager = AccessibilityManager.FromContext(Application.Context);
        }
        public override void Announcement(string message)
        {
            var accessibilityEvent = GetAccessibilityEvent(message, EventTypes.Announcement); 
            _accessibilityManager.SendAccessibilityEvent(accessibilityEvent);
        }

        public override void NavigationAnnouncement(string message)
        {
            var accessibilityEvent = GetAccessibilityEvent(message, EventTypes.WindowsChanged); 
            _accessibilityManager.SendAccessibilityEvent(accessibilityEvent);
        }
    
        public override bool IsScreenReaderEnabled()
        {
            var services = _accessibilityManager.GetEnabledAccessibilityServiceList(FeedbackFlags.Spoken);
            return services != null && services.Count > 0;
        }

        private AccessibilityEvent GetAccessibilityEvent(string message, EventTypes type)
        {
            var accessibilityEvent = new AccessibilityEvent();
            accessibilityEvent.EventType = type;
            accessibilityEvent.Text.Add(new Java.Lang.String(message));
            return accessibilityEvent;
        }
    }
}