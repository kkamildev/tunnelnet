
using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Components;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Components.Entities;

public class Player
{
    private Vector2 _position;
    private Sprite _sprite;
    public Player(Vector2 position)
    {
        _position = position;
        _sprite = new(Content.TextureName.MAIN_PLAYER, new Vector2(MainGame.Resolution.X / 2f, MainGame.Resolution.Y / 2f), 2.5f, Color.White, 0.5f, 0.5f, 0f);
    }

    public void Draw()
    {
        _sprite.Draw();
    }
}