using System.Threading.Tasks;
using Rg.Plugins.Popup.Interfaces.Animations;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Bitspace.UI.PopupAnimations
{
    public class Default : IPopupAnimation
    {
        public void Preparing(View content, PopupPage page)
        {
            throw new System.NotImplementedException();
        }

        public void Disposing(View content, PopupPage page)
        {
            throw new System.NotImplementedException();
        }

        public Task Appearing(View content, PopupPage page)
        {
            throw new System.NotImplementedException();
        }

        public Task Disappearing(View content, PopupPage page)
        {
            throw new System.NotImplementedException();
        }
    }
}