using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Xamarin.Forms;

namespace Bitspace.Effects
{
    [ExcludeFromCodeCoverage]
    public class ImageTintEffect : RoutingEffect
    {
        public ImageTintEffect()
            : base(EffectHelper.GetLocalName<ImageTintEffect>())
        {
        }

        public Color TintColor { get; set; }
    }
}