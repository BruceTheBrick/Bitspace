using System.Diagnostics.CodeAnalysis;
using Bitspace.Core;
using Xamarin.Forms;

namespace Bitspace.UI
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