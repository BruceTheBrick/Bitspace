using System.Diagnostics.CodeAnalysis;

namespace Bitspace.Core;

[ExcludeFromCodeCoverage]
public class AnimationService : IAnimationService
{
    public async Task FadeIn(View view, int milliseconds, Easing easing = null)
    {
        await view.FadeTo(0, 0);
        await view.FadeTo(1, (uint)milliseconds, easing);
    }

    public async Task FadeOut(View view, int milliseconds = 750, Easing easing = null)
    {
        await view.FadeTo(0, (uint)milliseconds, easing);
    }

    public async Task ScaleIn(View view)
    {
        await view.ScaleTo(0, 0);
        await view.ScaleTo(0, 200);
        await view.ScaleTo(1.5, 550);
        await view.ScaleTo(1);
    }

    public async Task Spin(View view, int milliseconds = 750)
    {
        var currentRotation = view.Rotation;
        await view.RotateTo(currentRotation + 360, (uint)milliseconds, Easing.Linear);
    }
}