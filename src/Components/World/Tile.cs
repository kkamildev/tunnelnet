

using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Components;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Components.World;

public class Tile
{
    protected Sprite _sprite;

    protected Vector2 _position;

    public Tile(Content.TextureName texture, Vector2 position)
    {
        _position = position;
        _sprite = new(texture, _position * 64, 2f, Color.White);
    }

    public void Draw()
    {
        _sprite.Draw();
    }

    public void Update(Vector2 cameraPosition)
    {
        _sprite.SetPosition((_position - cameraPosition) * 64f + MainGame.Resolution / 2 - new Vector2(_sprite.Rectangle.Width, _sprite.Rectangle.Height) / 2);
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