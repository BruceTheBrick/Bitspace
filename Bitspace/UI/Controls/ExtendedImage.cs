using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Maui.Behaviors;

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

        // view.AddTintEffect();
    }

    private void SetBaseSource(string source)
    {
        base.Source = source;
    }

    private void AddTintEffect()
    {
        RemoveTintEffect();
        var behaviour = new IconTintColorBehavior { TintColor = TintColor };
        Behaviors.Add(behaviour);
    }

    private void RemoveTintEffect()
    {
        var effect = Behaviors.FirstOrDefault(x => x is IconTintColorBehavior);
        if (effect is not null)
        {
            Behaviors.Remove(effect);
        }
    }
}