using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bitspace.Core;
using Xamarin.Forms;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    public class AccessibilityTraits
    {
        public static readonly BindableProperty TraitsProperty =
            BindableProperty.CreateAttached(
                "Traits",
                typeof(TraitsEnum),
                typeof(AccessibilityTraits),
                default(TraitsEnum),
                propertyChanged: TraitsPropertyChanged);

        public static TraitsEnum GetTraits(BindableObject view)
        {
            return (TraitsEnum)view.GetValue(TraitsProperty);
        }

        public static void SetTraits(BindableObject view, TraitsEnum traits)
        {
            view.SetValue(TraitsProperty, traits);
        }

        private static void TraitsPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            var traitEffect = view.Effects.FirstOrDefault(x => x.GetType() == typeof(AccessibilityTraitsEffect));
            if (traitEffect == null)
            {
                view.Effects.Add(new AccessibilityTraitsEffect());
            }
        }

        [ExcludeFromCodeCoverage]
        public class AccessibilityTraitsEffect : RoutingEffect
        {
            public AccessibilityTraitsEffect()
                : base(EffectHelper.GetLocalName<AccessibilityTraitsEffect>())
            {
            }
        }
    }

}

