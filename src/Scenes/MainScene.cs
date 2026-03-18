

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Components.Entities;

namespace Tunnelnet.Scenes;

public sealed class MainScene : Scene
{
    private Player _player;
    public MainScene(MainGame game) : base(game)
    {
        _player = new(new Vector2(0, 0));
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp);
        
        _player.Draw();
        
        MainGame.Batch.End();
        base.Draw();
    }

    public override void Update()
    {
        base.Update();
    }
}