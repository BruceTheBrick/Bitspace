using System.ComponentModel;
using Bitspace.iOS.Effects;
using Bitspace.UI;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(AccessibilityTraitsEffect), nameof(AccessibilityTraits.AccessibilityTraitsEffect))] 
namespace Bitspace.iOS.Effects
{
    public class AccessibilityTraitsEffect : PlatformEffect
    {
        private UIView _view;
        protected override void OnAttached()
        {
            _view = Control ?? Container;
            if (_view == null)
            {
                return;
            }

            SetTraits();
        }
        
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (_view == null)
            {
                return;
            }
            
            if (args.PropertyName == AccessibilityTraits.TraitsProperty.PropertyName ||
                args.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
            {
                SetTraits();
            }
        }

        protected override void OnDetached()
        {
        }
        
        private void SetTraits()
        {
            var traits = AccessibilityTraits.GetTraits(Element);
            _view.AccessibilityTraits = (UIAccessibilityTrait)traits;
        }
    }
}