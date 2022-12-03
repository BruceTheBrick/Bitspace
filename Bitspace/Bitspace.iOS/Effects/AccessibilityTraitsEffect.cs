using Bitspace.Core;
using Bitspace.Effects;
using Bitspace.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(AccessibilityTraitsEffect), nameof(AccessibilityTraits))] 
namespace Bitspace.iOS.Effects
{
    public class AccessibilityTraitsEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Element == null)
            {
                return;
            }
            
            SetTraits();
        }

        protected override void OnDetached()
        {
        }

        private void SetTraits()
        {
            // var traits = AccessibilityTraits.
        }
    }
}