using System;
using System.Collections.Generic;
using Bitspace.Core;
using Firebase.Analytics;
using Foundation;

namespace Bitspace.iOS.Services
{
    public class FirebaseAnalyticsService : IFirebaseAnalyticsService
    {
        public void LogEvent(string eventId)
        {
            throw new NotImplementedException();
        }

        public void LogEvent(string eventId, string paramName, string value)
        {
            var parameters = new Dictionary<string, string>
            {
                { paramName, value }
            };
            LogEvent(eventId, parameters);
        }

        public void LogEvent(string eventId, IDictionary<string, string> parameters)
        {
            
            Analytics.LogEvent(eventId, ConvertParameters(parameters));
        }

        public void SetUserId(string userId)
        {
            Analytics.SetUserId(userId);
        }

        private NSDictionary<NSString, NSObject> ConvertParameters(IDictionary<string, string> parameters)
        {
            var keys = new List<NSString>();
            var values = new List<NSString>();
            foreach (var item in parameters)
            {
                keys.Add(new NSString(item.Key));
                values.Add(new NSString(item.Value));
            }

            return NSDictionary<NSString, NSObject>.FromObjectsAndKeys(values.ToArray(), keys.ToArray(), keys.Count);
        }
    }
}

