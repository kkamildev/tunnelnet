


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Utils.Managers;
using Tunnelnet.Utils.Components.Wallpapers;
using Tunnelnet.Components.Entities;

namespace Tunnelnet.Scenes;

public sealed class HubScene : Scene
{
    private LoadingWallpaper _loadingWallpaper;
    private Player _player;
    public HubScene(MainGame game) : base(game)
    {
        _loadingWallpaper = new(Content.TextureName.PIXEL, "Stange Forest", "The Dense center of adventure", 3, 0.22f, 0.88f)
        {
            Color = Color.Black
        };
        _player = new(Vector2.Zero);
        
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp, blendState: BlendState.NonPremultiplied);

        _loadingWallpaper.Draw();
        if(_loadingWallpaper.Progress >= 0.88f)
        {
            _game.GraphicsDevice.Clear(Color.Green);
            _player.Draw();
        }

        MainGame.Batch.End();
    }

    public override void Update()
    {
        _loadingWallpaper.Update();
        if(_loadingWallpaper.Progress >= 0.88f)
        {
            _player.Update();
        }
    }
}