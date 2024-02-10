using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls.Shapes;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public partial class LoadingPill
{
    public LoadingPill()
    {
        InitializeComponent();
    }

    private void LoadingPill_OnSizeChanged(object sender, EventArgs e)
    {
        var strokeShape = new RoundRectangle { CornerRadius = (float)Height / 2 };
        StrokeShape = strokeShape;
    }
}