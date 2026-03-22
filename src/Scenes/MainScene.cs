

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Components.Entities;
using Tunnelnet.Utils.Components.Text;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Scenes;

public sealed class MainScene : Scene
{
    public MainScene(MainGame game) : base(game)
    {
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp);
        
        
        MainGame.Batch.End();
        base.Draw();
    }

    public override void Update()
    {
        base.Update();
    }
}