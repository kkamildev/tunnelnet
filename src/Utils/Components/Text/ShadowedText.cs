

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Utils.Components.Text;

public sealed class ShadowedText : RotatedText
{
    private byte _shadowValue;
    public ShadowedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign, float rotation, byte shadowValue) : base(fontName, content, position, xAlign, yAlign, rotation)
    {
        _shadowValue = shadowValue;
    }
    public ShadowedText(Content.FontName fontName, string content, Vector2 position, float xAlign, float yAlign, byte shadowValue) : base(fontName, content, position, xAlign, yAlign, 0f)
    {
        _shadowValue = shadowValue;
    }

    public override void Draw()
    {
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position + new Vector2(_shadowValue, _shadowValue), new Color(0, 0, 0, (int)Color.A), Rotation, new Vector2(_TextSize.X * _xAlign, _TextSize.Y * _yAlign), Scale, SpriteEffects.None, 0f);
        base.Draw();
    }
    
}