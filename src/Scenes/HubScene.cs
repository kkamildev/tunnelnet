


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Utils.Managers;
using Tunnelnet.Utils.Components.Wallpapers;
using Tunnelnet.Components.Entities;
using Tunnelnet.Components.World;

namespace Tunnelnet.Scenes;

public sealed class HubScene : Scene
{
    private readonly LoadingWallpaper _loadingWallpaper;
    private Player _player;
    private Tile _tile, _tile2;
    public HubScene(MainGame game) : base(game)
    {
        _loadingWallpaper = new(Content.TextureName.PIXEL, "Strange Forest", "The Dense center of adventure", 3, 0.22f, 0.88f)
        {
            Color = Color.Black
        };
        _player = new(Vector2.Zero);
        _tile = new Tile(Content.TextureName.GRASS_TILE, new Vector2(0, 0));
        _tile2 = new Tile(Content.TextureName.GRASS_TILE, new Vector2(1, 1));
        
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp, blendState: BlendState.NonPremultiplied);

        _loadingWallpaper.Draw();
        if(_loadingWallpaper.Progress >= 0.88f)
        {
            _game.GraphicsDevice.Clear(Color.Green);
            _tile.Draw();
            _tile2.Draw();
            _player.Draw();
        }

        MainGame.Batch.End();
    }

    public override void Update()
    {
        _loadingWallpaper.Update();
        _tile.Update(_player.Position);
        _tile2.Update(_player.Position);
        if(_loadingWallpaper.Progress >= 0.88f)
        {
            _player.Update();
        }
    }
}