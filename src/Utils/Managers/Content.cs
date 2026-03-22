

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tunnelnet.Utils.Managers;

public sealed partial class Content
{
    private readonly string _fontsPath;
    private readonly string _texturesPath;
    private readonly string _soundsPath;
    private ContentManager _contentManager;
    private Dictionary<FontName, SpriteFont> _fonts;
    private Dictionary<TextureName, Texture2D> _textures;
    private Dictionary<SoundName, SoundEffect> _soundEffects;
    public Content(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _fontsPath = "fonts/descriptions/";
        _texturesPath = "textures/";
        _soundsPath = "sounds/";
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
        Texture2D pixel = new(MainGame.Graph.GraphicsDevice, 1, 1);
        pixel.SetData([Color.White]);
        
        _textures = new()
        {
            {TextureName.PIXEL, pixel},
            { TextureName.MAIN_PLAYER, _contentManager.Load<Texture2D>(_texturesPath + "players/mainPlayer") },
            {TextureName.GRASS_TILE, _contentManager.Load<Texture2D>(_texturesPath + "tiles/grass")}
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