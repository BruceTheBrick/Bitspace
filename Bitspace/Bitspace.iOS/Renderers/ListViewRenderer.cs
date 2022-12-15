using System.ComponentModel;
using Bitspace.iOS.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer (typeof(ListView), typeof(ListViewRenderer))]
namespace Bitspace.iOS.Renderers
{
    public class ListViewRenderer : Xamarin.Forms.Platform.iOS.ListViewRenderer
    { 
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null)
            {
                return;
            }
            
            if (Control.AccessibilityLabel != null && Control.AccessibilityLabel.ToLower().Equals("empty list"))
            {
                Control.AccessibilityLabel = string.Empty;
            }
        }
    }
}