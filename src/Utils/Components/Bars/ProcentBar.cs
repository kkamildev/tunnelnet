

using System;
using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Components.Text;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Utils.Components.Bars;

public class ProcentBar
{
    private Rectangle _rect;
    private OutlinedText _text;
    private float _progress;
    private string _beforeText;
    private Color _color;
    public ProcentBar(Rectangle rect, float progress, Content.FontName font, string beforeText, Color color)
    {
        _rect = rect;
        _color = color;
        _progress = progress;
        _beforeText = beforeText;
        _text = new(font, beforeText + ((int)Math.Round(progress * 100)).ToString() + "%", new Vector2(rect.X + rect.Width / 2, rect.Y + rect.Height / 2), 0.5f, 0.5f, 3);
    }

    public void Draw()
    {
        int borderValue = 4;
        MainGame.Batch.Draw(MainGame.CM.GetTexture(Content.TextureName.PIXEL), new Rectangle(_rect.X - borderValue, _rect.Y - borderValue, _rect.Width + borderValue * 2, _rect.Height + borderValue * 2), Color.Black);
        MainGame.Batch.Draw(MainGame.CM.GetTexture(Content.TextureName.PIXEL), new Rectangle(_rect.X, _rect.Y, (int)(_rect.Width * _progress), _rect.Height), _color);
        MainGame.Batch.Draw(MainGame.CM.GetTexture(Content.TextureName.PIXEL), new Rectangle(_rect.X, _rect.Y + (int)Math.Ceiling(_rect.Height / 3f) * 2, (int)(_rect.Width * _progress), (int)(_rect.Height / 3f)), _color * 0.5f);
        MainGame.Batch.Draw(MainGame.CM.GetTexture(Content.TextureName.PIXEL), new Rectangle(_rect.X, _rect.Y + (int)Math.Ceiling(_rect.Height / 2f), (int)(_rect.Width * _progress), (int)(_rect.Height / 2f)), _color * 0.5f);
        _text.Draw();
    }

    public float Progress
    {
        get
        {
            return _progress;
        }   
        set
        {
            _progress = value;
            _text.Content = _beforeText + ((int)Math.Round(_progress * 100)).ToString() + "%";
        }
    }
    
}