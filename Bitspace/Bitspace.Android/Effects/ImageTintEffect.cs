using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Android.Graphics;
using Android.Widget;
using Bitspace.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ImageTintEffect), nameof(Bitspace.UI.ImageTintEffect))]
namespace Bitspace.Droid.Effects
{
    [ExcludeFromCodeCoverage]
    public class ImageTintEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!(Control is ImageView image))
            {
                return;
            }

            var effect = (UI.ImageTintEffect)Element.Effects.FirstOrDefault(x => x is UI.ImageTintEffect);
            if (effect != null)
            {
                var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                image.SetColorFilter(filter);
            }
        }

        protected override void OnDetached()
        {
            if (!(Control is ImageView image))
            {
                return;
            }
            
            image.SetColorFilter(null);
        }
    }
}