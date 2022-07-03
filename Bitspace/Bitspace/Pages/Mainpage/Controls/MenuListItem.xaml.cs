using Bitspace.Pages.Mainpage.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bitspace.Pages.Mainpage.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MenuListItem
{
    public static readonly BindableProperty MenuListItemViewModelProperty = BindableProperty.Create(
        nameof(MenuListItemViewModel),
        typeof(MenuListItemViewModel),
        typeof(MenuListItem),
        null,
        BindingMode.TwoWay);

    public static readonly BindableProperty IconTintProperty = BindableProperty.Create(
        nameof(IconTint),
        typeof(Color),
        typeof(MenuListItem),
        null,
        BindingMode.TwoWay);

    public static readonly BindableProperty ActionIconTintProperty = BindableProperty.Create(
        nameof(ActionIconTint),
        typeof(Color),
        typeof(MenuListItem),
        null,
        BindingMode.TwoWay);

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