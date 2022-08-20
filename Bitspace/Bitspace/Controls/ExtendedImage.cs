using System.Diagnostics.CodeAnalysis;
using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;

namespace Bitspace.Controls;

[ExcludeFromCodeCoverage]
public class ExtendedImage : SvgCachedImage
{
    public static new readonly BindableProperty SourceProperty = BindableProperty.Create(
        nameof(Source),
        typeof(string),
        typeof(ExtendedImage),
        string.Empty,
        BindingMode.TwoWay,
        propertyChanged: OnSourceUpdated);

    public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
        nameof(TintColor),
        typeof(Color),
        typeof(ExtendedImage),
        null,
        BindingMode.TwoWay,
        propertyChanged: TintColorUpdated);

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

    public Color TintColor
    {
        get => (Color)GetValue(TintColorProperty);
        set => SetValue(TintColorProperty, value);
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

    private static void TintColorUpdated(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is not ExtendedImage image)
        {
            return;
        }

        IconTintColorEffect.SetTintColor(image, (Color)newvalue);
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