
using System;

namespace Tunnelnet.Utils.Animations;

public sealed class FadeAnimation : Timer
{
    private float _fadeInBarrier;
    private float _fadeOutBarrier;
    public FadeAnimation(float animationSeconds, float fadeInBarrier, float fadeOutBarrier) : base(animationSeconds)
    {
        _fadeInBarrier = Math.Max(fadeInBarrier, 0.01f);
        _fadeOutBarrier = Math.Max(fadeOutBarrier, 0.01f);
    }

    public float Alpha
    {
        get
        {
            if(_fadeInBarrier >= Progress)
            {
                return Progress / _fadeInBarrier;
            } else if(_fadeOutBarrier <= Progress)
            {
                return (1f - Progress) / (1f - _fadeOutBarrier);
            } else
            {
                return 1f;
            }
        }
    }
}