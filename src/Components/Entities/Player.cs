
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tunnelnet.Utils.Components;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Components.Entities;

public class Player
{
    private Vector2 _position;
    private Sprite _sprite;
    private byte _rotationValue = 0;
    public Player(Vector2 position)
    {
        _position = position;
        _sprite = new(Content.TextureName.MAIN_PLAYER, new Vector2(MainGame.Resolution.X / 2f, MainGame.Resolution.Y / 2f), 2f, Color.White, 0.5f, 0.5f, 0f);
    }

    public void Draw()
    {
        _sprite.Draw();
    }
    public void Update()
    {
        PerformControl();
    }

    private void PerformControl()
    {
        sbyte direction = -1;
        if(MainGame.Input.CheckPressed(Input.Controls.TARGET_TOP))
        {
            _rotationValue = 0;
            direction = 0;
        }
        if(MainGame.Input.CheckPressed(Input.Controls.TARGET_DOWN))
        {
            _rotationValue = 4;
            direction = 1;
        }
        if(MainGame.Input.CheckPressed(Input.Controls.TARGET_RIGHT))
        {
            if(direction == 0)
            {
                _rotationValue = 1;
            } else if(direction == 1)
            {
                _rotationValue = 3;
            } else
            {
                _rotationValue = 2;
            }
        }
        if(MainGame.Input.CheckPressed(Input.Controls.TARGET_LEFT))
        {
            if(direction == 0)
            {
                _rotationValue = 7;
            } else if(direction == 1)
            {
                _rotationValue = 5;
            }else
            {
                _rotationValue = 6;
            }
        }
        _sprite.DegRotation = _rotationValue * 45f;
    }
}