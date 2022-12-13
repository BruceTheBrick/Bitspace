namespace Bitspace.Core
{
    public interface IBaseService
    {
         INavigationService NavigationService { get; }
         IAccessibilityService AccessibilityService { get; }
         IAnalyticsService AnalyticsService { get; }
         IAlertService AlertService { get; }
    }
}