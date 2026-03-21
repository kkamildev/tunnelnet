
using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Utils.Components.Text;

public class Text
{
    protected readonly Content.FontName _fontName;
    protected string _content;
    private Vector2 _position;
    public Color Color{get;set;}

    public Text(Content.FontName fontName, string content, Vector2 position)
    {
        _fontName = fontName;
        Position = position;
        Content = content;
        Color = Color.White;
    }

    public Text(Content.FontName fontName, string content, Vector2 position, Color color)
    {
        _fontName = fontName;
        _content = content;
        _position = position;
        Color = color;
    }

    public virtual void Draw()
    {
        MainGame.Batch.DrawString(MainGame.CM.GetFont(_fontName), Content, Position, Color);
    }

    public virtual string Content
    {
        get
        {
            return _content;
        }
        set
        {
            _content = value;
        }
    }
    public Vector2 Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
        }
    }
}