using Prism.Navigation;

namespace Bitspace.Services
{
    public class BaseService : IBaseService
    {
        public BaseService(
            INavigationService navigationService,
            IAccessibilityService accessibilityService,
            IFirebaseAnalyticsService analyticsService)
        {
            NavigationService = navigationService;
            AccessibilityService = accessibilityService;
            AnalyticsService = analyticsService;
        }
    }
}