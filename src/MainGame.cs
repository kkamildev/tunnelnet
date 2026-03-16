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
    private RenderTarget2D _renderTarget2D;


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

        // setting resolution
        _renderTarget2D = new(GraphicsDevice, 1600, 900);
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
        GraphicsDevice.Clear(Color.Black);
        GraphicsDevice.SetRenderTarget(_renderTarget2D);

        // drawing logic here


        GraphicsDevice.SetRenderTarget(null);
        Batch.Begin();
        Batch.Draw(_renderTarget2D, new Rectangle(0, 0, (int)ScreenSize.X, (int)ScreenSize.Y), Color.White);
        Batch.End();
        base.Draw(gameTime);
    }
    public static void Shutdown()
    {
        _running = false;
    }
}
