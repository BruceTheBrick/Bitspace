using Bitspace.Core;
using Bitspace.Enums;
using Xamarin.Forms;

namespace Bitspace.Effects
{
    public class AccessibilityTraits : RoutingEffect
    {
        protected AccessibilityTraits()
            : base(EffectHelper.GetLocalName<AccessibilityTraits>())
        {

        public static readonly BindableProperty TraitsProperty = BindableProperty.Create(
            nameof(Traits),
            typeof(TraitsEnum),
            typeof(AccessibilityTraits));

        public TraitsEnum Traits
        {
            get => (TraitsEnum)GetValue(TraitsProperty);
            set => SetValue(TraitsProperty, value);
        }
    }
}
}