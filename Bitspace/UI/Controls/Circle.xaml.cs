using System.Diagnostics.CodeAnalysis;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public partial class Circle
{
    public Circle()
    {
        InitializeComponent();
    }

    private void Circle_OnSizeChanged(object sender, EventArgs e)
    {
        This.CornerRadius = (float)Height / 2;
    }
}