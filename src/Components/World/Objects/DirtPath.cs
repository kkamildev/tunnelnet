
using Microsoft.Xna.Framework;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Components.World.Objects;

public class RotatableObject : Object
{
    public RotatableObject(Content.TextureName texture, float degRotation) : base(texture)
    {
        _sprite.DegRotation = degRotation;
        _sprite = new(texture, _position * tileSize, tileSize / (float)MainGame.CM.GetTexture(texture).Width, Color.White, 0.5f, 0.5f, MathHelper.ToRadians(degRotation));
    }

    public override Vector2 Position {
        get => base.Position - new Vector2(0.5f, 0.5f);
        set => base.Position = value + new Vector2(0.5f, 0.5f);
    }

    public float DegRotation
    {
        get
        {
            return _sprite.DegRotation;
        }
        set
        {
            _sprite.DegRotation = value;
        }
    }
}