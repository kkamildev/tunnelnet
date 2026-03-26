


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Utils.Managers;
using Tunnelnet.Utils.Components.Wallpapers;
using Tunnelnet.Components.Entities;
using Tunnelnet.Components.World.Tiles;
using Tunnelnet.Components.World.Gen;
using Tunnelnet.Components.World.Objects;
using System;

namespace Tunnelnet.Scenes;

public sealed class HubScene : Scene
{
    private readonly LoadingWallpaper _loadingWallpaper;
    private Player _player;
    private Chunk _chuck, _chuck2, _chuck3;
    public HubScene(MainGame game) : base(game)
    {
        _loadingWallpaper = new(Content.TextureName.PIXEL, "Strange Forest", "The Dense center of adventure", 3, 0.22f, 0.88f)
        {
            Color = Color.Black
        };
        _player = new(Vector2.Zero);
        _chuck = new (Vector2.Zero);
        _chuck2 = new (new Vector2(1, 0));
        _chuck3 = new (new Vector2(0, 1));
        Random rn = new();

        for(byte i = 0;i<16;i++)
        {
            for(byte j = 0;j<16;j++)
            {
                _chuck.SetTile(j, i, new Tile(Content.TextureName.GRASS_TILE));
                _chuck2.SetTile(j, i, new Tile(Content.TextureName.DARK_GRASS_TILE));
                _chuck3.SetTile(j, i, new Tile(Content.TextureName.LIGHT_GRASS_TILE));
            }
        }
        _chuck.SetObject(1, 0, new RotatableObject(Content.TextureName.DIRT_PATH_END, 0));
        for(byte i = 1;i<14;i++)
        {
            _chuck.SetObject(1, i, new RotatableObject(Content.TextureName.DIRT_PATH, 0));
            _chuck.SetObject(2, i, new RotatableObject(Content.TextureName.DIRT_PATH, 0));
            _chuck.SetObject(3, i, new RotatableObject(Content.TextureName.ROSES, (int)(rn.NextSingle() * 4) * 90));
            _chuck.SetObject(4, i, new RotatableObject(Content.TextureName.DANDELIONS, (int)(rn.NextSingle() * 4) * 90));
            _chuck.SetObject(5, i, new RotatableObject(Content.TextureName.LILIES, (int)(rn.NextSingle() * 4) * 90));
        }
        _chuck.SetObject(1, 14, new RotatableObject(Content.TextureName.DIRT_PATH_END, 180));
        _chuck.SetObject(2, 14, new RotatableObject(Content.TextureName.DIRT_PATH_END, 180));
        for(byte i = 1;i<16;i++)
        {
            _chuck.SetObject(i, 15, new RotatableObject(Content.TextureName.DIRT_PATH, 90));
        }
        
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp, blendState: BlendState.NonPremultiplied);

        if(_loadingWallpaper.Progress >= 0.88f)
        {
            _game.GraphicsDevice.Clear(Color.Green);
            _chuck.Draw(_player.Position);
            _chuck2.Draw(_player.Position);
            _chuck3.Draw(_player.Position);
            _player.Draw();
            MainGame.Batch.DrawString(MainGame.CM.GetFont(Content.FontName.SMALL), _player.Position.ToString(), Vector2.Zero, Color.White);
        }
        _loadingWallpaper.Draw();

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
            _chuck3.Update(_player.Position);
        }
    }
}