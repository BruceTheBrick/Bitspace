using System;
using System.Collections.Generic;
using System.Linq;
using Bitspace.iOS.Effects;
using Bitspace.UI;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(SemanticOrderEffect), nameof(SemanticOrder.ExtendedSemanticOrderEffect))] 
namespace Bitspace.iOS.Effects
{
    public class SemanticOrderEffect : PlatformEffect, IUIAccessibilityContainer
    {
        public IntPtr Handle { get; }
        private List<View> _accessibleChildren;

        protected override void OnAttached()
        {
            if (Element == null || Control == null)
            {
                return;
            }

            if (_accessibleChildren == null)
            {
                InitAccessibleChildren();
            }

            // this.SetAccessibilityElements();
        }

        private void InitAccessibleChildren()
        {
            _accessibleChildren = new List<View>();
            foreach (var child in Element.LogicalChildren)
            {
                if (child is not View childView) continue;
                if (childView.TabIndex != 0)
                {
                    _accessibleChildren.Add(childView);
                }
            }
            
            _accessibleChildren = _accessibleChildren.OrderBy(x => x).ToList();
        }

        protected override void OnDetached()
        {
        }
        public void Dispose()
        {
        }
    }
}