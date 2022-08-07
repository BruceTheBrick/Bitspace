using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace Bitspace.Controls;

public class ExtendedImage : SvgCachedImage
{
    public static new readonly BindableProperty SourceProperty = BindableProperty.Create(
        nameof(Source),
        typeof(string),
        typeof(ExtendedImage),
        string.Empty,
        BindingMode.TwoWay,
        propertyChanged: OnSourceUpdated);

    public static readonly BindableProperty ExtensionProperty = BindableProperty.Create(
        nameof(Extension),
        typeof(string),
        typeof(ExtendedImage),
        "svg",
        BindingMode.TwoWay);

    private const string SourcePrefix = "resource://Bitspace.Resources.";
    public new string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public string Extension
    {
        get => (string)GetValue(ExtensionProperty);
        set => SetValue(ExtensionProperty, value);
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
        return $"{SourcePrefix}{input}.{Extension}";
    }

    private void SetBaseSource(string source)
    {
        ((CachedImage)this).Source = source;
    }
}