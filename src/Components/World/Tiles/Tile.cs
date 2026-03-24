

using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Components;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Components.World.Tiles;

public class Tile
{
    protected Sprite _sprite;

    protected Vector2 _position;

    public static Vector2 aligmentValue = MainGame.Resolution / 2 - new Vector2(32, 32) / 2; 
    public static readonly int tileSize = 64;

    public Tile(Content.TextureName texture)
    {
        _position = Vector2.Zero;
        _sprite = new(texture, _position * tileSize, tileSize / (float)MainGame.CM.GetTexture(texture).Width, Color.White);
    }

    public void Draw()
    {
        _sprite.Draw();
        MainGame.Batch.DrawString(MainGame.CM.GetFont(Content.FontName.SMALL), "obj in screen", new Vector2(0, 50), Color.White);
    }

    public void Update(Vector2 cameraPosition)
    {
        _sprite.SetPosition((_position - cameraPosition) * tileSize + aligmentValue);
    }

    public Vector2 Position
    {
        set
        {
            _position = value;
        }
        get
        {
            return _position;
        }
    }
}