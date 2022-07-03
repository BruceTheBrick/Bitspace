using System;
using System.Globalization;
using Bitspace.APIs.OpenWeather.Response_Models;
using Xamarin.Forms;

namespace Bitspace.Converters;

public class ObjectToAccessibilityTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? null : ObjectToString(value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    private string ObjectToString(object input)
    {
        var accessibilityString = string.Empty;
        switch (input)
        {
            case (MainResponseModel model):
            {
                accessibilityString = $"Humidity: {model.Humidity}" +
                                      $"Pressure: {model.Pressure}" +
                                      $"Temperature: {model.Temperature}";
                break;
            }
        }

        return accessibilityString;
    }
}