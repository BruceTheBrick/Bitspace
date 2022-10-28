using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bitspace.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(ImageTintEffect), nameof(Bitspace.Effects.ImageTintEffect))]
namespace Bitspace.iOS.Effects
{
    [ExcludeFromCodeCoverage]
    public class ImageTintEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!(Control is UIImageView image) || image.Image == null)
            {
                return;
            }

            var effect = (Bitspace.Effects.ImageTintEffect)Element.Effects.FirstOrDefault(x => x is Bitspace.Effects.ImageTintEffect);
            if (effect == null)
            {
                return;
            }
            
            image.Image = image.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            image.TintColor = effect.TintColor.ToUIColor();
        }

        protected override void OnDetached()
        {
            if (!(Control is UIImageView image && image.Image != null))
            {
                return;
            }

            image.Image = image.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
        }
    }
}