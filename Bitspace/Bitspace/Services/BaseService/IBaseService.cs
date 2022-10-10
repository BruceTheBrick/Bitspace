namespace Bitspace.Services
{
    public interface IBaseService
    {
         INavigationService NavigationService { get; }
         IAccessibilityService AccessibilityService { get; }
         IFirebaseAnalyticsService AnalyticsService { get; }
    }
}