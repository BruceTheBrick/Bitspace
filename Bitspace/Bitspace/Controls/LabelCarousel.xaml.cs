using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bitspace.Controls;

[ExcludeFromCodeCoverage]
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class LabelCarousel
{
    public static readonly BindableProperty TextListProperty = BindableProperty.Create(
        nameof(TextList),
        typeof(IEnumerable<string>),
        typeof(LabelCarousel),
        new ObservableCollection<string>(),
        BindingMode.TwoWay);

    public static readonly BindableProperty MillisecondsProperty = BindableProperty.Create(
        nameof(Milliseconds),
        typeof(int),
        typeof(LabelCarousel),
        5,
        BindingMode.TwoWay);

    public LabelCarousel()
    {
        InitializeComponent();
    }

    public IEnumerable<string> TextList
    {
        get => (IEnumerable<string>)GetValue(TextListProperty);
        set => SetValue(TextListProperty, value);
    }

    public int Milliseconds
    {
        get => (int)GetValue(MillisecondsProperty);
        set => SetValue(MillisecondsProperty, value);
    }
}