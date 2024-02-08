using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Features;

[ExcludeFromCodeCoverage]
public partial class InfoCard
{
    public static readonly BindableProperty HumidityProperty = BindableProperty.Create(
        nameof(Humidity),
        typeof(double),
        typeof(InfoCard),
        0.0,
        BindingMode.TwoWay);

    public static readonly BindableProperty WindSpeedProperty = BindableProperty.Create(
        nameof(WindSpeed),
        typeof(double),
        typeof(InfoCard),
        0.0,
        BindingMode.TwoWay);

    public static readonly BindableProperty PressureProperty = BindableProperty.Create(
        nameof(Pressure),
        typeof(double),
        typeof(InfoCard),
        0.0,
        BindingMode.TwoWay);

    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
        nameof(IsLoading),
        typeof(bool),
        typeof(InfoCard),
        null,
        BindingMode.TwoWay);

    public InfoCard()
    {
            InitializeComponent();
        }

    public double Humidity
    {
        get => (double)GetValue(HumidityProperty);
        set => SetValue(HumidityProperty, value);
    }

    public double WindSpeed
    {
        get => (double)GetValue(WindSpeedProperty);
        set => SetValue(WindSpeedProperty, value);
    }

    public double Pressure
    {
        get => (double)GetValue(PressureProperty);
        set => SetValue(PressureProperty, value);
    }

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }
}