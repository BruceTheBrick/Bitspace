using System;
using System.Collections.Generic;
using Bitspace.Styles;
using Xamarin.Forms;

namespace Bitspace.Controls;

[ContentProperty("Contents")]
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

    public SkeletonSection()
    {
        InitializeComponent();
        SetDefaultLoadingColor();
    }

    public IList<View> Contents => ContentStack.Children;

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

    private void SetDefaultLoadingColor()
    {
        if (LoadingBackgroundColor != default)
        {
            return;
        }

        if (Application.Current.Resources.TryGetValue("LoadingColor", out var color))
        {
            LoadingBackgroundColor = (ColorRef)color;
        }
    }
}