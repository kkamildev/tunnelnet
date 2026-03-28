
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tunnelnet.Utils.Components;
using Tunnelnet.Utils.Components.Text;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Components.Entities;

public class Player
{

    public class PlayerInterface
    {
        private Player _player;
        private Sprite _interfaceSprite;
        private OutlinedText _nicknameText;
        private OutlinedText _floorText, _floorSubtitleText;
        private Sprite _heartIcon;
        public PlayerInterface(Player player, Vector2 position)
        {
            _player = player;
            _interfaceSprite = new(Content.TextureName.PLAYER_STATS, position, 2f, Color.White);
            _nicknameText = new(Content.FontName.SMALL, _player.Nickname, position + new Vector2(8, 6), 0f, 0f, 3);
            _floorSubtitleText = new(Content.FontName.SMALL, "Floor", position + new Vector2(50, 90), 0.5f, 0.5f, 3);
            _floorText = new(Content.FontName.MEDIUM, "1", position + new Vector2(50, 60), 0.5f, 0.5f, 4);
            _heartIcon = new(Content.TextureName.HEART_ICON, position + new Vector2(90, 30), 2f, Color.White);
        }

        public void Draw()
        {
            // _interfaceSprite.Draw();
            _nicknameText.Draw();
            _heartIcon.Draw();
            if(_floorText != null)
            {
                _floorText.Draw();
                _floorSubtitleText.Draw();
            }
        }

        public OutlinedText FloorText
        {
            set
            {
                _floorText = value;
            }
        }
        public int Floor
        {
            set
            {
                _floorText.Content = value.ToString();
            }
        }
    }
    private Vector2 _position;
    private Sprite _sprite;
    private byte _rotationValue = 0;
    private int _playerSpeed = 7;
    private Vector2 _previrousMousePosiston;
    public PlayerInterface Interface{get;private set;}
    public string Nickname{get;private set;}
    public Player(Vector2 position, Vector2 interfacePosition, string nickname)
    {
        _position = position;
        Nickname = nickname;
        _sprite = new(Content.TextureName.MAIN_PLAYER, new Vector2(MainGame.Resolution.X / 2f, MainGame.Resolution.Y / 2f), 2f, Color.White, 0.5f, 0.5f, 0f);
        Interface = new(this, interfacePosition);
    }

    public void Draw()
    {
        _sprite.Draw();
    }

    public void DrawInterface()
    {
       Interface.Draw();
    }

    public void Update()
    {
        PerformRotation();
        PerformMouseRotation();
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

    private void PerformMouseRotation()
    {
        if(_previrousMousePosiston != MainGame.Input.MousePosition)
        {
            Vector2 direction = MainGame.Input.MousePosition - MainGame.Resolution / 2f;
            float angle = -(float)Math.Atan2(direction.X, direction.Y);

            _rotationValue = (byte)(Math.Round(MathHelper.ToDegrees(angle) + 180 + 32) / 45);
            _sprite.DegRotation = _rotationValue * 45f;

            // mouse border
            Vector2 centerMousePos = MainGame.Input.MousePosition - MainGame.Resolution / 2f;
            if(Math.Abs(centerMousePos.X) > 200 || Math.Abs(centerMousePos.Y) > 200)
            {
               MainGame.Input.MousePosition -= new Vector2((float)(Math.Sin(-angle) * 100), (float)(Math.Cos(-angle) * 100));
            }
            _previrousMousePosiston = MainGame.Input.MousePosition;
        }
        
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
            _position.X+= (float)(xMove * Math.Sqrt(2) / 2) * _playerSpeed * MainGame.DeltaTime;
            _position.Y+= (float)(yMove * Math.Sqrt(2) / 2) * _playerSpeed * MainGame.DeltaTime;
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