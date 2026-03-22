


using Microsoft.Xna.Framework;
using Tunnelnet.Components.Entities;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Utils.Components.Text;
using Tunnelnet.Utils.Animations;

namespace Tunnelnet.Scenes;

public sealed class HubScene : Scene
{
    private Player _player;
    public HubScene(MainGame game) : base(game)
    {
        _player = new(Vector2.Zero);
        
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp, blendState: BlendState.AlphaBlend);
        _player.Draw();
        MainGame.Batch.End();
    }

    public override void Update()
    {
        
        _player.Update();
    }
}