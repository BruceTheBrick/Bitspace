using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Bitspace.Resources;
using Microsoft.Maui.Controls.Shapes;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
[ContentProperty(nameof(Contents))]
public partial class SkeletonSection
{
    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
        nameof(IsLoading),
        typeof(bool),
        typeof(SkeletonSection),
        false,
        BindingMode.TwoWay);

    public static readonly BindableProperty LoadingBackgroundColorProperty = BindableProperty.Create(
        nameof(LoadingBackgroundColor),
        typeof(Color),
        typeof(SkeletonSection),
        default,
        BindingMode.TwoWay);

    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
        nameof(CornerRadius),
        typeof(int),
        typeof(SkeletonSection),
        16,
        BindingMode.TwoWay,
        propertyChanged: OnCornerRadiusChanged);

    public SkeletonSection()
    {
        InitializeComponent();
        SetDefaultLoadingColor();
    }

    public IList<IView> Contents
    {
        set
        {
            foreach (var element in value)
            {
                ContentStack.AddLogicalChild((Element)element);
            }
        }

        get => ContentStack?.Children ?? new List<IView>();
    }

public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public Color LoadingBackgroundColor
    {
        get => (Color)GetValue(LoadingBackgroundColorProperty);
        set => SetValue(LoadingBackgroundColorProperty, value);
    }

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    private static void OnCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not SkeletonSection skeletonSection)
        {
            return;
        }

        skeletonSection.Skeleton.StrokeShape = new RoundRectangle { CornerRadius = (int)newValue };
    }

    private void SetDefaultLoadingColor()
    {
        if (LoadingBackgroundColor != default)
        {
            return;
        }

        LoadingBackgroundColor = ResourceHelper.GetResource<ColorRef>("LoadingColor");
    }
}