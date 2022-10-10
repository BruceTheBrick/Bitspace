using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bitspace.Services
{
    public interface IAnimationService
    {
        public Task FadeIn(View view, int milliseconds = 750, Easing easing = null);
        public Task FadeOut(View view, int milliseconds = 750, Easing easing = null);
        public Task ScaleIn(View view);
        public Task Spin(View view, int milliseconds = 750);
    }
}