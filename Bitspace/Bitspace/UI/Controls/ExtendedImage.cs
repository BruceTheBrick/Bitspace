using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Bitspace.Resources;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public class ExtendedImage : Image
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
        typeof(ColorRef),
        typeof(ExtendedImage),
        ResourceHelper.GetResource<ColorRef>("IconPrimaryColor"),
        propertyChanged: TintColorUpdated);

    public new string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public ColorRef TintColor
    {
        get => (ColorRef)GetValue(TintColorProperty);
        set => SetValue(TintColorProperty, value);
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == TintColorProperty.PropertyName ||
            propertyName == IsEnabledProperty.PropertyName)
        {
            AddTintEffect();
        }
    }

    private static void OnSourceUpdated(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not ExtendedImage image)
        {
            return;
        }

        if (newValue is string newSource)
        {
            image.SetBaseSource(newSource);
        }
    }

    private static void TintColorUpdated(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not ExtendedImage view)
        {
            return;
        }

        view.AddTintEffect();
    }

    private void SetBaseSource(string source)
    {
        ((Image)this).Source = source;
    }

    private void AddTintEffect()
    {
        RemoveTintEffect();
        var effect = new ImageTintEffect { TintColor = TintColor };
        Effects.Add(effect);
    }

    private void RemoveTintEffect()
    {
        var effect = Effects.FirstOrDefault(x => x is ImageTintEffect);
        if (effect is not null)
        {
            Effects.Remove(effect);
        }
    }
}