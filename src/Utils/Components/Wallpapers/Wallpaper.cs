


using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Utils.Components.Wallpapers;


public class Wallpaper
{
    private Content.TextureName _texture;
    public Color Color{get;set;}
    public Wallpaper(Content.TextureName texture)
    {
        _texture = texture;
    }
    
    public virtual void Draw()
    {
        MainGame.Batch.Draw(MainGame.CM.GetTexture(_texture), new Rectangle(0, 0, (int)MainGame.Resolution.X, (int)MainGame.Resolution.Y), Color);
    }
    public float Alpha
    {
        set
        {
            Color newColor = new(Color.R, Color.G, Color.B, value);
            Color = newColor;
        }
    }
}