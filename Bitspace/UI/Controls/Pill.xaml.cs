using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls.Shapes;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public partial class Pill
{
    public Pill()
    {
        InitializeComponent();
    }

    private void Pill_OnSizeChanged(object sender, EventArgs e)
    {
        // CornerRadius = (float)Height / 2;
        var strokeShape = new RoundRectangle { CornerRadius = (float)Height / 2 };
        StrokeShape = strokeShape;
    }
}