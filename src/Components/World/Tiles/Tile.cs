

using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Components;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Components.World.Tiles;

public class Tile
{
    protected Sprite _sprite;

    protected Vector2 _position;

    private static Vector2 aligmentValue = MainGame.Resolution / 2 - new Vector2(32, 32) / 2; 
    private static readonly int tileSize = 64;

    public Tile(Content.TextureName texture, Vector2 position)
    {
        _position = position;
        _sprite = new(texture, _position * tileSize, tileSize / (float)MainGame.CM.GetTexture(texture).Width, Color.White);
    }

    public void Draw()
    {
        _sprite.Draw();
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