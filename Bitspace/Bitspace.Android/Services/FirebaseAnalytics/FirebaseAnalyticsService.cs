using System.Collections.Generic;
using Android.OS;
using Bitspace.Core;
using Firebase.Analytics;
using Plugin.CurrentActivity;

namespace Bitspace.Droid.Services
{
    public class FirebaseAnalyticsService : IFirebaseAnalyticsService
    {
        public void LogEvent(string eventId)
        {
            LogEvent(eventId, null);
        }

        public void LogEvent(string eventId, string paramName, string value)
        {
            var parameters = new Dictionary<string, string> { { paramName, value } };
            LogEvent(eventId, parameters);
        }

        public void LogEvent(string eventId, IDictionary<string, string> parameters)
        {
            var analytics = FirebaseAnalytics.GetInstance(CrossCurrentActivity.Current.AppContext);
            analytics.LogEvent(eventId, GetBundle(parameters));
        }

        public void SetUserId(string userId)
        {
            var analytics = FirebaseAnalytics.GetInstance(CrossCurrentActivity.Current.AppContext);
            analytics.SetUserId(userId);
        }

        private Bundle GetBundle(IDictionary<string, string> parameters)
        {
            var bundle = new Bundle();
            foreach (var parameter in parameters)
            {
                bundle.PutString(parameter.Key, parameter.Value);
            }

            return bundle;
        }
    }
}