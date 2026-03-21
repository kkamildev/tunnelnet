

using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace Tunnelnet.Utils.Components.Text;

public class RotatedText : AlignedText
{
    private float _rotation;
    
    public RotatedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign, float rotation) : base(fontName, content, position, xAlign, yAlign)
    {
        _rotation = rotation;
    }

    public RotatedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign) : base(fontName, content, position, xAlign, yAlign)
    {
        _rotation = 0f;
    }

    public override void Draw()
    {
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position, Color, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), 1f, SpriteEffects.None, 0f);
    }

    public float DegRotation
    {
        get
        {
            return MathHelper.ToDegrees(_rotation);
        }
        set
        {
            _rotation = MathHelper.ToRadians(value);
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
}