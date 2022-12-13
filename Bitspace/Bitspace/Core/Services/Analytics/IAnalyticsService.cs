using System.Collections.Generic;

namespace Bitspace.Core
{
    public interface IAnalyticsService
    {
        void LogEvent(string eventId);
        void LogEvent(string eventId, string paramName, string value);
        void LogEvent(string eventId, IDictionary<string, string> parameters);
        void SetUserId(string userId);
    }
}
