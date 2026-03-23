
using System;
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
    private int _playerSpeed = 5;
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
        PerformRotation();
        PerformMovement();
    }

    private void PerformRotation()
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

    private void PerformMovement()
    {
        sbyte xMove = 0;
        sbyte yMove = 0;
        if(MainGame.Input.CheckPressed(Input.Controls.FORWARD))
        {
            yMove-= 1;
        }
        if(MainGame.Input.CheckPressed(Input.Controls.BACKWARD))
        {
            yMove+= 1;
        }
        if(MainGame.Input.CheckPressed(Input.Controls.LEFT))
        {
            xMove-= 1;
        }
        if(MainGame.Input.CheckPressed(Input.Controls.RIGHT))
        {
            xMove+= 1;
        }
        if(Math.Abs(xMove) == Math.Abs(yMove))
        {
            _position.X+= (float)(xMove * Math.Sqrt(2)) * _playerSpeed * MainGame.DeltaTime;
            _position.Y+= (float)(yMove * Math.Sqrt(2)) * _playerSpeed * MainGame.DeltaTime;
        } else
        {
            _position.X+= xMove * _playerSpeed * MainGame.DeltaTime;
            _position.Y+= yMove * _playerSpeed * MainGame.DeltaTime;
        }
    }
    public Vector2 Position
    {
        get
        {
            return _position;
        }
    }
}