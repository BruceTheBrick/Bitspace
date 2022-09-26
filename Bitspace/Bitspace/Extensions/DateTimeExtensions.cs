using System;

namespace Bitspace.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDisplayString(this DateTime datetime)
        {
            var dayName = datetime.ToString("dddd");
            var shortMonth = datetime.ToString("MMM");
            var date = datetime.Day;
            return $"{dayName}, {date} {shortMonth}";
        }
    }
}