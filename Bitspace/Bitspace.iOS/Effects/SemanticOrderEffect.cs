using System.Collections.Generic;
using System.Linq;
using Bitspace.iOS.Effects;
using Bitspace.UI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(SemanticOrderEffect), nameof(SemanticOrder.ExtendedSemanticOrderEffect))] 
namespace Bitspace.iOS.Effects
{
    public class SemanticOrderEffect : PlatformEffect
    {
        private List<View> accessibleChildren;
        protected override void OnAttached()
        {
            if (Element == null || Control == null)
            {
                return;
            }

            if (accessibleChildren == null)
            {
                InitAccessibleChildren();
            }
        }

        protected override void OnDetached()
        {
        }

        private void InitAccessibleChildren()
        {
            accessibleChildren = new List<View>();
            foreach (var child in Element.LogicalChildren)
            {
                if (child is not View childView) continue;
                if (childView.TabIndex != 0)
                {
                    accessibleChildren.Add(childView);
                }
            }
            
            accessibleChildren = accessibleChildren.OrderBy(x => x).ToList();
        }
    }
}