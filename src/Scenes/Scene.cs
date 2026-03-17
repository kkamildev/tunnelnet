

namespace Tunnelnet.Scenes;

public abstract class Scene
{
    protected MainGame _game;
    public Scene(MainGame game)
    {
        _game = game;
    }

    public virtual void Draw()
    {
        
    }
    public virtual void Update()
    {
        
    }
}