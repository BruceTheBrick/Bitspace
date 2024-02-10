using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Bitspace.Resources;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public partial class BaseButton
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(BaseButton));

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(BaseButton));

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(BaseButton));


    public static readonly BindableProperty ActiveBackgroundColorProperty = BindableProperty.Create(
        nameof(ActiveBackgroundColor),
        typeof(ColorRef),
        typeof(BaseButton));

    public static readonly BindableProperty ActiveTextColorProperty = BindableProperty.Create(
        nameof(ActiveTextColor),
        typeof(ColorRef),
        typeof(BaseButton));

    public static readonly BindableProperty InactiveBackgroundColorProperty = BindableProperty.Create(
        nameof(InactiveBackgroundColor),
        typeof(ColorRef),
        typeof(BaseButton));

    public static readonly BindableProperty InactiveTextColorProperty = BindableProperty.Create(
        nameof(InactiveTextColor),
        typeof(ColorRef),
        typeof(BaseButton));

    public BaseButton()
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

    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public ColorRef ActiveTextColor
    {
        get => (ColorRef)GetValue(ActiveTextColorProperty);
        set => SetValue(ActiveTextColorProperty, value);
    }

    public ColorRef ActiveBackgroundColor
    {
        get => (ColorRef)GetValue(ActiveBackgroundColorProperty);
        set => SetValue(ActiveBackgroundColorProperty, value);
    }

    public ColorRef InactiveTextColor
    {
        get => (ColorRef)GetValue(InactiveTextColorProperty);
        set => SetValue(InactiveTextColorProperty, value);
    }

    public ColorRef InactiveBackgroundColor
    {
        get => (ColorRef)GetValue(InactiveBackgroundColorProperty);
        set => SetValue(InactiveBackgroundColorProperty, value);
    }
}