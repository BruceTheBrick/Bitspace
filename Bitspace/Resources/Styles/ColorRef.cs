using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Resources;

[ExcludeFromCodeCoverage]
public class ColorRef
{
    public ColorRef()
    {
    }

    public ColorRef(Color color)
    {
        Color = color;
    }

    public Color Color { get; set; }

    public static implicit operator Color(ColorRef x)
    {
        return x.Color;
    }

    public Color ToColor()
    {
        return Color;
    }
}