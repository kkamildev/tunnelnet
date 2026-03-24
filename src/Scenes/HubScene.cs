


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Utils.Managers;
using Tunnelnet.Utils.Components.Wallpapers;
using Tunnelnet.Components.Entities;
using Tunnelnet.Components.World.Tiles;
using Tunnelnet.Components.World.Gen;

namespace Tunnelnet.Scenes;

public sealed class HubScene : Scene
{
    private readonly LoadingWallpaper _loadingWallpaper;
    private Player _player;
    private Chunk _chuck, _chuck2;
    public HubScene(MainGame game) : base(game)
    {
        _loadingWallpaper = new(Content.TextureName.PIXEL, "Strange Forest", "The Dense center of adventure", 3, 0.22f, 0.88f)
        {
            Color = Color.Black
        };
        _player = new(Vector2.Zero);
        _chuck = new (Vector2.Zero);
        _chuck2 = new (new Vector2(1, 0));

        for(byte i = 0;i<16;i++)
        {
            for(byte j = 0;j<16;j++)
            {
                _chuck.SetTile(j, i, new Tile(Content.TextureName.GRASS_TILE));
            }
        }
        for(byte i = 0;i<16;i++)
        {
            for(byte j = 0;j<16;j++)
            {
                _chuck2.SetTile(j, i, new Tile(Content.TextureName.GRASS_TILE));
            }
        }
        
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp, blendState: BlendState.NonPremultiplied);

        _loadingWallpaper.Draw();
        if(_loadingWallpaper.Progress >= 0.88f)
        {
            _game.GraphicsDevice.Clear(Color.Green);
            _chuck.Draw(_player.Position);
            _chuck2.Draw(_player.Position);
            _player.Draw();
            MainGame.Batch.DrawString(MainGame.CM.GetFont(Content.FontName.SMALL), _player.Position.ToString(), Vector2.Zero, Color.White);
        }

        MainGame.Batch.End();
    }

    public override void Update()
    {
        _loadingWallpaper.Update();
        if(_loadingWallpaper.Progress >= 0.88f)
        {
            _player.Update();
            _chuck.Update(_player.Position);
            _chuck2.Update(_player.Position);
        }
    }
}