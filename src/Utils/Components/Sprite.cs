
namespace Tunnelnet.Utils.Components;

using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Managers;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Sprite
{
    private const int SPRITE_WIDTH = 32;
    private const int SPRITE_HEIGHT = 32;
    private Content.TextureName _texture;
    private Rectangle _rectangle;
    private float _xAlign, _yAlign;
    private float _scale;
    public Color Color {get;set;}
    private float _rotation;
    public Sprite(Content.TextureName texture, Vector2 position)
    {
        _texture = texture;
        _scale = 1;
        Color = Color.White;
        _xAlign = 0;
        _yAlign = 0;
        _rotation = 0;
    }
    public Sprite(Content.TextureName texture, Vector2 position, float scale, Color color) : this(texture, position)
    {
        Color = color;
        _scale = scale;
        SetPosition(position);
    }
    public Sprite(Content.TextureName texture, Vector2 position, float scale, Color color, float xAlign, float yAlign, float rotation) : this(texture, position, scale, color)
    {
        _xAlign = xAlign;
        _yAlign = yAlign;
        _rotation = rotation;
        SetPosition(position);
    }

    public void Draw()
    {
        MainGame.Batch.Draw(MainGame.CM.GetTexture(_texture), _rectangle, null, Color, _rotation, new Vector2(SPRITE_WIDTH * _xAlign, SPRITE_HEIGHT * _yAlign), SpriteEffects.None, 0f);
    }

    public void SetPosition(Vector2 position)
    {
        _rectangle = new((int)position.X, (int)position.Y, (int)(SPRITE_WIDTH * _scale), (int)(SPRITE_HEIGHT * _scale));
    }

    public float DegRotation
    {
        get
        {
            return MathHelper.ToDegrees(_rotation);
        }
        set
        {
            _rotation = MathHelper.ToRadians(_rotation);
        }
    }
    public float Rotation
    {
        get
        {
            return _rotation;
        }
        set
        {
            _rotation = value;
        }
    }
    public Rectangle Rectangle {
        get
        {
            return _rectangle;
        }
    }
}