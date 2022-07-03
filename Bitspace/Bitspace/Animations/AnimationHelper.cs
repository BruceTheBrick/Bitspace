using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bitspace.Animations;

public class AnimationHelper
{
    public async Task FadeIn(View view, int milliseconds, Easing easing = null)
    {
        await view.FadeTo(0, 0);
        await view.FadeTo(1, (uint)milliseconds, easing);
    }
}