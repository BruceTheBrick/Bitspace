using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class MenuListItem
{
    public static readonly BindableProperty MenuListItemViewModelProperty = BindableProperty.Create(
        nameof(MenuListItemViewModel),
        typeof(MenuListItemViewModel),
        typeof(MenuListItem));

    public static readonly BindableProperty IconTintProperty = BindableProperty.Create(
        nameof(IconTint),
        typeof(Color),
        typeof(MenuListItem));

    public static readonly BindableProperty ActionIconTintProperty = BindableProperty.Create(
        nameof(ActionIconTint),
        typeof(Color),
        typeof(MenuListItem));

    public MenuListItem()
    {
        InitializeComponent();
    }

    public MenuListItemViewModel MenuListItemViewModel
    {
        get => (MenuListItemViewModel)GetValue(MenuListItemViewModelProperty);
        set => SetValue(MenuListItemViewModelProperty, value);
    }

    public Color IconTint
    {
        get => (Color)GetValue(IconTintProperty);
        set => SetValue(IconTintProperty, value);
    }

    public Color ActionIconTint
    {
        get => (Color)GetValue(IconTintProperty);
        set => SetValue(IconTintProperty, value);
    }
}