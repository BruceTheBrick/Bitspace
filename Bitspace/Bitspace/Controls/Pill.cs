using Xamarin.Forms;

namespace Bitspace.Controls;

public class Pill : Button
{
    public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
        nameof(IsActive),
        typeof(bool),
        typeof(Pill),
        propertyChanged: IsActivePropertyUpdated);

    public Pill()
    {
    }

    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    private static void IsActivePropertyUpdated(BindableObject bindable, object oldvalue, object newvalue)
    {
        // TODO Implement IOS Trait for 'Selected' here
    }
}