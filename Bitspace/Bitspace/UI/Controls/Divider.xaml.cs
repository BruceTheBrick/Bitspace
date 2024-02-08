using System.Diagnostics.CodeAnalysis;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public partial class Divider
{
    private static new readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(Color),
        typeof(Color),
        typeof(Divider),
        Colors.White,
        BindingMode.TwoWay);

    private static readonly BindableProperty ThicknessProperty = BindableProperty.Create(
        nameof(Thickness),
        typeof(int),
        typeof(Divider),
        1,
        BindingMode.TwoWay);

    private bool _isVertical;

    public Divider()
    {
        InitializeComponent();
        UpdateUi();
    }

    public bool IsVertical
    {
        get => _isVertical;
        set
        {
            if (_isVertical == value)
            {
                return;
            }

            _isVertical = value;
            UpdateUi();
        }
    }

    public new Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public int Thickness
    {
        get => (int)GetValue(ThicknessProperty);
        set => SetValue(ThicknessProperty, value);
    }

    private void UpdateUi()
    {
        if (IsVertical)
        {
            InitVerticalDivider();
        }
        else
        {
            InitHorizontalDivider();
        }
    }

    private void InitHorizontalDivider()
    {
        This.HeightRequest = Thickness;
        This.HorizontalOptions = LayoutOptions.FillAndExpand;
        This.VerticalOptions = LayoutOptions.Center;
    }

    private void InitVerticalDivider()
    {
        This.WidthRequest = Thickness;
        This.VerticalOptions = LayoutOptions.FillAndExpand;
        This.HorizontalOptions = LayoutOptions.Center;
    }
}