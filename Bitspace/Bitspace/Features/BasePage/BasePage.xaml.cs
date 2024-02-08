using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class BasePage
{
    public static readonly BindableProperty IsNavigationBarVisibleProperty = BindableProperty.Create(
        nameof(IsNavigationBarVisible),
        typeof(bool),
        typeof(BasePage));

    public BasePage()
    {
        InitializeComponent();
    }

    public bool IsNavigationBarVisible
    {
        get => (bool)GetValue(IsNavigationBarVisibleProperty);
        set => SetValue(IsNavigationBarVisibleProperty, value);
    }
}