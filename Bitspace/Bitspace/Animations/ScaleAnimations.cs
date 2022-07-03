using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bitspace.Animations;

public class ScaleAnimations
{
    public async Task ScaleIn(View view)
    {
        await view.ScaleTo(0, 0);
        await view.ScaleTo(0, 200);
        await view.ScaleTo(1.5, 550);
        await view.ScaleTo(1, 250);
    }
}