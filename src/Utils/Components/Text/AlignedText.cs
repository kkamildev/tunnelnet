

using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace Tunnelnet.Utils.Components.Text;

public class AlignedText : Text
{
    protected float _xAlign, _yAlign;
    protected Vector2 _TextSize;
    
    public AlignedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign) : base(fontName, content, position)
    {
        _xAlign = xAlign;
        _yAlign = yAlign;
    }

    public override void Draw()
    {
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position, Color, 0f, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
    }

    public override string Content
    {
        get => base.Content;
        set
        {
            _content = value;
            _TextSize = MainGame.CM.GetFont(_fontName).MeasureString(_content);
        }
    }

    public Vector2 TextSize
    {
        get
        {
            return _TextSize;
        }
    }
}