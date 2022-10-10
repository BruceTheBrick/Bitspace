using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Services
{
    [ExcludeFromCodeCoverage]
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