using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace Bitspace.Controls;

[ExcludeFromCodeCoverage]
public partial class LoadingCard
{
    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
        nameof(IsLoading),
        typeof(bool),
        typeof(LoadingCard),
        false,
        BindingMode.TwoWay);

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(LoadingCard),
        string.Empty,
        BindingMode.TwoWay);

    public LoadingCard()
    {
        InitializeComponent();
    }

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}