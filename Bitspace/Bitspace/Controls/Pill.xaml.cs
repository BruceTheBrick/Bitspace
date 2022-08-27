using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bitspace.Controls;

[ExcludeFromCodeCoverage]
public partial class Pill
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(Pill),
        string.Empty,
        BindingMode.TwoWay);

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(Pill));

    public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(
        nameof(IsEnabled),
        typeof(bool),
        typeof(Pill),
        true,
        BindingMode.TwoWay,
        propertyChanged: IsEnabledPropertyChanged);

    public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
        nameof(IsActive),
        typeof(bool),
        typeof(Pill),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty PaddingProperty = BindableProperty.Create(
        nameof(Padding),
        typeof(Thickness),
        typeof(Pill),
        new Thickness(15, 10),
        BindingMode.TwoWay);

    public Pill()
    {
        InitializeComponent();
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public bool IsEnabled
    {
        get => (bool)GetValue(IsEnabledProperty);
        set => SetValue(IsEnabledProperty, value);
    }

    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    public Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }

    private static void IsEnabledPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is Pill pill)
        {
            pill.Command?.CanExecute((bool)newvalue);
        }
    }
}