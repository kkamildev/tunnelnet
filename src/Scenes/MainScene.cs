

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tunnelnet.Components.Entities;
using Tunnelnet.Utils.Components.Text;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet.Scenes;

public sealed class MainScene : Scene
{
    private Player _player;
    private OutlinedText _shadowedText;
    public MainScene(MainGame game) : base(game)
    {
        _player = new(new Vector2(0, 0));
        _shadowedText = new (Content.FontName.BIG, "Hello world", new Vector2(400, 400), 0.5f, 0.5f, 10);
    }

    public override void Draw()
    {
        MainGame.Batch.Begin(samplerState:SamplerState.PointClamp);
        
        _player.Draw();
        _shadowedText.Draw();
        
        MainGame.Batch.End();
        base.Draw();
    }

    public override void Update()
    {
        _player.Update();
        base.Update();
    }
}