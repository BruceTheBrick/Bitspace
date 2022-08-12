using Xamarin.Forms;

namespace Bitspace.Controls;

public partial class Divider
{
    private bool _isVertical;

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(Color),
        typeof(Color),
        typeof(Divider),
        Color.White,
        BindingMode.TwoWay);

    public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(
        nameof(Thickness),
        typeof(int),
        typeof(Divider),
        1,
        BindingMode.TwoWay);

    public Divider()
    {
        InitializeComponent();
        UpdateUI();
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
            UpdateUI();
        }
    }

    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public int Thickness
    {
        get => (int)GetValue(ThicknessProperty);
        set => SetValue(ThicknessProperty, value);
    }

    private void UpdateUI()
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