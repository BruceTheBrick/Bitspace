using Prism.Navigation;

namespace Bitspace.Services
{
    public class IBaseService
    {
        public INavigationService NavigationService;
        public IAccessibilityService AccessibilityService;
        public IFirebaseAnalyticsService AnalyticsService;
    }
}