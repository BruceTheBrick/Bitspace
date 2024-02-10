namespace Bitspace.Core;

public static class DateTimeExtensions
{
    public static string ToDisplayString(this DateTime datetime)
    {
        var dayName = datetime.ToString("dddd");
        var shortMonth = datetime.ToString("MMM");
        var date = datetime.Day;
        return $"{dayName}, {date} {shortMonth}";
    }

    public static long ToUnixSeconds(this DateTime dateTime)
    {
        var offset = new DateTimeOffset(dateTime);
        return offset.ToUnixTimeSeconds();
    }
}