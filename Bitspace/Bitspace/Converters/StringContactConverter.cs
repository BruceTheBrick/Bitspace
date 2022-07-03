using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Bitspace.Converters;

public class StringContactConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null || !targetType.IsAssignableFrom(typeof(string)))
        {
            return false;
        }

        return values.OfType<string>().Aggregate(string.Empty, (current, value) => current + value);
    }


    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return null;
    }
}