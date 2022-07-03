using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bitspace.Markup_Extensions;

[ContentProperty(nameof(Key))]
public class KeyValueExtension : BindableObject, IMarkupExtension
{
    public static readonly BindableProperty KeyProperty = BindableProperty.Create(
        nameof(Key),
        typeof(string),
        typeof(KeyValueExtension),
        string.Empty,
        BindingMode.TwoWay);


    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value),
        typeof(string),
        typeof(KeyValueExtension),
        string.Empty,
        BindingMode.TwoWay);

    public string Key
    {
        get => (string)GetValue(KeyProperty);
        set => SetValue(KeyProperty, value);
    }

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return $"{Key} {Value}";
    }
}