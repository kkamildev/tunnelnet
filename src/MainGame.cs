using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tunnelnet;

public class MainGame : Game
{
    public static GraphicsDeviceManager Graph {get; private set;}
    public static SpriteBatch Batch {get;private set;}
    public static Vector2 ScreenSize {get;private set;}
    private static bool _running = true;

    public MainGame()
    {
        Graph = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        ScreenSize = new(GraphicsDevice.Adapter.CurrentDisplayMode.Width, GraphicsDevice.Adapter.CurrentDisplayMode.Height);

        Graph.PreferredBackBufferWidth = (int)ScreenSize.X;
        Graph.PreferredBackBufferHeight = (int)ScreenSize.Y;
        Graph.ToggleFullScreen();
        Graph.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Batch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if(!_running)
        {
            Exit();
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Shutdown();
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        base.Draw(gameTime);
    }
    public static void Shutdown()
    {
        _running = false;
    }
}
