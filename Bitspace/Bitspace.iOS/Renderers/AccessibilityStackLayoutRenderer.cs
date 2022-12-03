using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bitspace.Core.Models;
using Bitspace.iOS.Renderers;
using Bitspace.UI;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(AccessibilityStackLayout), typeof(AccessibilityStackLayoutRenderer))]
namespace Bitspace.iOS.Renderers
{
    [ExcludeFromCodeCoverage]
    public class AccessibilityStackLayoutRenderer : VisualElementRenderer<StackLayout>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            if (HasIncrementOrDecrementImplementation())
            {
                NativeView.AccessibilityTraits |= UIAccessibilityTrait.Adjustable;
            }
            
            SetAccessibilityActions();
        }

        public override void AccessibilityIncrement()
        {
            base.AccessibilityIncrement();
            if (Element is AccessibilityStackLayout element)
            {
                element.AccessibilityIncrementCommand?.Execute(null);
            }
        }
        
        public override void AccessibilityDecrement()
        {
            base.AccessibilityDecrement();
            if (Element is AccessibilityStackLayout element)
            {
                element.AccessibilityDecrementCommand?.Execute(null);
            }
        }

        private void SetAccessibilityActions()
        {
            if (!(Element is AccessibilityStackLayout))
            {
                return;
            }

            var commands = GetCommandsFromElement();
            var accessibilityActions = new List<UIAccessibilityCustomAction>();
            foreach (var command in commands)
            {
                accessibilityActions.Add(new UIAccessibilityCustomAction(command.ActionName, actionHandler: ExecuteCustomAction));
            }

            AccessibilityCustomActions = accessibilityActions.ToArray();
        }

        private bool ExecuteCustomAction(UIAccessibilityCustomAction action)
        {
            var commands = GetCommandsFromElement();
            var currentCommand = commands.FirstOrDefault(x => x.ActionName == action.Name);
            if (currentCommand == null)
            {
                return false;
            }
            
            currentCommand.Command?.Execute(null);
            return true;
        }
        
        private IList<AccessibilityActionCommand> GetCommandsFromElement()
        {
            if (!(Element is AccessibilityStackLayout element) 
                 || element.AccessibilityActionCommandList == null 
                 || element.AccessibilityActionCommandList.Count == 0)
            {
                return new List<AccessibilityActionCommand>();
            }

            return element.AccessibilityActionCommandList;
        }

        private bool HasIncrementOrDecrementImplementation()
        {
            if (!(Element is AccessibilityStackLayout element))
            {
                return false;
            }

            return element.AccessibilityDecrementCommand != null 
                   || element.AccessibilityIncrementCommand != null;
        }
    }
}