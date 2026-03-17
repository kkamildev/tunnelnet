

using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tunnelnet.Utils.Managers;

public sealed partial class Content
{
    private readonly string _fontsPath;
    private ContentManager _contentManager;
    private Dictionary<FontName, SpriteFont> _fonts;
    private Dictionary<TextureName, Texture2D> _textures;
    private Dictionary<SoundName, SoundEffect> _soundEffects;
    public Content(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _fontsPath = "fonts/descriptions/";
    }

    public void LoadFonts()
    {
        _fonts = new()
        {
            { FontName.BASE, _contentManager.Load<SpriteFont>(_fontsPath + "base") },
            { FontName.SMALL, _contentManager.Load<SpriteFont>(_fontsPath + "small") },
            { FontName.BIG, _contentManager.Load<SpriteFont>(_fontsPath + "big") },
            { FontName.BIGGER, _contentManager.Load<SpriteFont>(_fontsPath + "bigger") },
            { FontName.MEDIUM, _contentManager.Load<SpriteFont>(_fontsPath + "medium") },
            { FontName.HUGE, _contentManager.Load<SpriteFont>(_fontsPath + "huge") }
        };
    }

    public void LoadTextures()
    {
        _textures = new()
        {
            
        };
    }
    
    public void LoadSoundEffects()
    {
        _soundEffects = new()
        {
            
        };
    }

    public SpriteFont GetFont(FontName fontName)
    {
        return _fonts[fontName];
    }

    public Texture2D GetTexture(TextureName textureName)
    {
        return _textures[textureName];
    }
    
    public SoundEffect GetSound(SoundName soundName)
    {
        return _soundEffects[soundName];
    }

}