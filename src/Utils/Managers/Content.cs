

using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tunnelnet.Utils.Managers;

public sealed partial class Content
{
    private ContentManager _contentManager;
    private Dictionary<FontName, SpriteFont> _fonts;
    public Content(ContentManager contentManager)
    {
        _contentManager = contentManager;
    }

    public void LoadFonts()
    {
        _fonts = new()
        {
            { FontName.BASE, _contentManager.Load<SpriteFont>("fonts/description/base") }
        };
    }


}