using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bitspace.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(ImageTintEffect), nameof(ImageTintEffect))]
namespace Bitspace.iOS.Effects;

[ExcludeFromCodeCoverage]
public class ImageTintEffect : PlatformEffect
{
    protected override void OnAttached()
    {
        SetTint();
    }

    protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
    {
        base.OnElementPropertyChanged(args);
        SetTint();
    }

    protected override void OnDetached()
    {
        if (!(Control is UIImageView image && image.Image != null))
        {
            return;
        }

        image.Image = image.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
    }

    private void SetTint()
    {
        if (!(Control is UIImageView image) || image.Image == null)
        {
            return;
        }
            
        var effect = (UI.ImageTintEffect)Element.Effects.FirstOrDefault(x => x is UI.ImageTintEffect);
        if (effect == null)
        {
            return;
        }
            
        image.Image = image.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
        image.TintColor = effect.TintColor.Color.ToUIColor();
    }
}