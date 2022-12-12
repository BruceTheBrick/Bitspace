using System.ComponentModel;
using Bitspace.Core;
using Bitspace.Droid.Effects;
using Bitspace.UI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(AccessibilityTraitsEffect), nameof(AccessibilityTraitsEffect))] 
namespace Bitspace.Droid.Effects
{
    public class AccessibilityTraitsEffect : PlatformEffect
    {
        private Android.Views.View _view;

        protected override void OnAttached()
        {
            if (Element == null)
            {
                return;
            }

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
            var controlTraits = AccessibilityTraits.GetTraits(Element);

            SetClickable(controlTraits.HasFlag(TraitsEnum.Button));
            SetSelected(controlTraits.HasFlag(TraitsEnum.Selected));
            SetEnabled();
            SetHeader(controlTraits.HasFlag(TraitsEnum.Header));
        }

        private void SetClickable(bool isClickable)
        {
            _view.Clickable = isClickable;
        }

        private void SetSelected(bool isSelected)
        {
            _view.Selected = isSelected;
        }

        private void SetEnabled()
        {
            if (!(Element is View view))
            {
                return;
            }

            _view.Enabled = view.IsEnabled;
        }

        private void SetHeader(bool isHeader)
        {
            _view.AccessibilityHeading = isHeader;
        }
    }
}