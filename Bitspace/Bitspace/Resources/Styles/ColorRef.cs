using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Resources;

[ExcludeFromCodeCoverage]
public struct ColorRef
{
    public ColorRef(Color color)
    {
        Color = color;
    }

    public Color Color { get; set; }

    public static implicit operator Color(ColorRef x)
    {
        return x.Color;
    }
}