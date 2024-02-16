using System.Diagnostics.CodeAnalysis;

namespace Bitspace.UI;

[ExcludeFromCodeCoverage]
public class ImageTintEffect : RoutingEffect
{
    public ImageTintEffect()
        : base(EffectHelper.GetLocalName<ImageTintEffect>())
    {
    }

    public ColorRef TintColor { get; set; }
}