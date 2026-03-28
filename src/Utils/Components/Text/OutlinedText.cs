


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Utils.Components.Text;

public sealed class OutlinedText : RotatedText
{
    private byte _outlineValue;
    public OutlinedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign, float rotation, byte outlineValue) : base(fontName, content, position, xAlign, yAlign, rotation)
    {
        _outlineValue = outlineValue;
    }
    public OutlinedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign, float rotation, byte outlineValue, Color color) : base(fontName, content, position, xAlign, yAlign, rotation, color)
    {
        _outlineValue = outlineValue;
    }
    public OutlinedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign, byte outlineValue) : base(fontName, content, position, xAlign, yAlign, 0f)
    {
        _outlineValue = outlineValue;
    }

    public override void Draw()
    {
        Color shadowColor = new(0, 0, 0, (int)Color.A);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(_outlineValue, 0), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(-_outlineValue, 0), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(0, _outlineValue), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(0, -_outlineValue), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(_outlineValue, _outlineValue), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(-_outlineValue, -_outlineValue), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(_outlineValue, -_outlineValue), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(-_outlineValue, _outlineValue), shadowColor, Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        base.Draw();
    }
    
}