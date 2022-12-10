using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core
{
    [ExcludeFromCodeCoverage]
    public class BaseService : IBaseService
    {
        public BaseService(
            INavigationService navigationService,
            IAccessibilityService accessibilityService,
            IFirebaseAnalyticsService analyticsService,
            IAlertService alertService)
        {
            NavigationService = navigationService;
            AccessibilityService = accessibilityService;
            AnalyticsService = analyticsService;
            AlertService = alertService;
        }

        public INavigationService NavigationService { get; }
        public IAccessibilityService AccessibilityService { get; }
        public IFirebaseAnalyticsService AnalyticsService { get; }
        public IAlertService AlertService { get; }
    }
}