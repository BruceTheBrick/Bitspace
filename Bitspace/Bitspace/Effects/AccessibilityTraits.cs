using Bitspace.Core;
using Bitspace.Enums;
using Xamarin.Forms;

namespace Bitspace.Effects
{
    public class AccessibilityTraits : RoutingEffect
    {
        public AccessibilityTraits()
            : base(nameof(AccessibilityTraits))
        {
        }

        public static readonly BindableProperty TraitsProperty =
            BindableProperty.CreateAttached(
                "Traits",
                typeof(TraitsEnum),
                typeof(AccessibilityTraits),
                default(TraitsEnum));

        public static TraitsEnum GetTraits(BindableObject view)
        {
            return (TraitsEnum)view.GetValue(TraitsProperty);
        }

        public static void SetTraits(BindableObject view, TraitsEnum traits)
        {
            view.SetValue(TraitsProperty, traits);
        }
    }
}

