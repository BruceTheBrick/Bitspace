using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace Bitspace.Controls;

public class ExtendedImage : SvgCachedImage
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        nameof(ImageSource),
        typeof(string),
        typeof(ExtendedImage),
        string.Empty,
        BindingMode.TwoWay,
        propertyChanged: OnSourceUpdated);

    private const string SourcePrefix = "resource://Bitspace.Resource.";
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    private static void OnSourceUpdated(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not ExtendedImage image)
        {
            return;
        }

        var source = image.FormatSource((string)newvalue);
        image.SetBaseSource(source);
    }

    private string FormatSource(string input)
    {
        return $"{SourcePrefix}{input}.svg";
    }

    private void SetBaseSource(string source)
    {
        Source = source;
    }
}