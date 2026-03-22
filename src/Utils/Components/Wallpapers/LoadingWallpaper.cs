

using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Animations;
using Tunnelnet.Utils.Components.Text;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Utils.Components.Wallpapers;


public sealed class LoadingWallpaper : Wallpaper
{
    private AlignedText _title;
    private AlignedText _subtitle; 
    private FadeAnimation _animation;
    public LoadingWallpaper(Content.TextureName texture, string title, string subtitle) : base(texture)
    {
        _title = new(Content.FontName.BIG, title, MainGame.Resolution / 2f, 0.5f, 0.5f);
        _subtitle = new(Content.FontName.MEDIUM, subtitle, (MainGame.Resolution / 2f) + new Vector2(0, 100), 0.5f, 0.5f);
        _animation = new(5, 0.22f, 0.88f);
    }

    public LoadingWallpaper(Content.TextureName texture, string title, string subtitle, float animationDuration, float fadeInBarrier, float fadeOutBarrier) : base(texture)
    {
        _title = new(Content.FontName.BIG, title, MainGame.Resolution / 2f, 0.5f, 0.5f);
        _subtitle = new(Content.FontName.MEDIUM, subtitle, (MainGame.Resolution / 2f) + new Vector2(0, 100), 0.5f, 0.5f);
        _animation = new(animationDuration, fadeInBarrier, fadeOutBarrier);
    }

    public override void Draw()
    {
        base.Draw();
        _title.Draw();
        _subtitle.Draw();
    }

    public void Update()
    {
        _animation.Update();
        _title.Alpha = _animation.Alpha;
        _subtitle.Alpha = _animation.Alpha;
        Alpha = _animation.Alpha;
    }

    public float Progress
    {
        get
        {
            return _animation.Progress;
        }
        set
        {
            _animation.Progress = value;
        }
    }
}