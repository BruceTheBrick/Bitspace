using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Xamarin.Forms;

namespace Bitspace.Converters;

[ExcludeFromCodeCoverage]
public class TemperatureToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var temp = value as double?;
        return temp switch
        {
            <= 18 => Color.CornflowerBlue,
            > 18 and <= 24 => Color.Green,
            > 24 => Color.OrangeRed,
            _ => Color.Fuchsia
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}