using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls.Shapes;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public partial class BaseCircleButton
{
    public BaseCircleButton()
    {
        InitializeComponent();
    }

    private void BaseCircleButton_OnSizeChanged(object sender, EventArgs e)
    {
        var strokeShape = new RoundRectangle { CornerRadius = (float)Height / 2 };
        StrokeShape = strokeShape;
    }
}