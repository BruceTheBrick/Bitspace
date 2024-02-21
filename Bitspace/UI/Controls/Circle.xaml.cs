using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls.Shapes;

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
        StrokeShape = new RoundRectangle { CornerRadius = (float)Height / 2 };
    }
}