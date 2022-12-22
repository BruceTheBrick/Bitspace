using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bitspace.Core;
using Xamarin.Forms;

namespace Bitspace.UI
{
    [ExcludeFromCodeCoverage]
    public class SemanticOrder
    {
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.CreateAttached(
            "IsEnabled",
            typeof(bool),
            typeof(SemanticOrder),
            false,
            propertyChanged: IsEnabledChanged);

        public static bool GetIsEnabled(BindableObject view)
        {
            return (bool)view.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(BindableObject view, bool IsEnabled)
        {
            view.SetValue(IsEnabledProperty, IsEnabled);
        }

        private static void IsEnabledChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            var oldEffect = view.Effects.FirstOrDefault(x => x.GetType() == typeof(ExtendedSemanticOrderEffect));
            if (oldEffect == null)
            {
                view.Effects.Add(new ExtendedSemanticOrderEffect());
            }
        }

        public class ExtendedSemanticOrderEffect : RoutingEffect
        {
            public ExtendedSemanticOrderEffect()
                : base(EffectHelper.GetLocalName<ExtendedSemanticOrderEffect>())
            {
            }
        }
    }
}