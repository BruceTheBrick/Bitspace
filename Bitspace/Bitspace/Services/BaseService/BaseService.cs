using Bitspace.Services.NavigationService;

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

        public INavigationService NavigationService { get; }
        public IAccessibilityService AccessibilityService { get; }
        public IFirebaseAnalyticsService AnalyticsService { get; }
    }
}