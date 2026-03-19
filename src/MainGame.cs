using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tunnelnet.Scenes;
using Tunnelnet.Utils.Managers;

namespace Tunnelnet;

public class MainGame : Game
{
    public static GraphicsDeviceManager Graph {get; private set;}
    public static SpriteBatch Batch {get;private set;}
    public static Vector2 ScreenSize {get;private set;}
    public static Vector2 Resolution {get;private set;}
    public static Content CM {get;private set;}
    public static Input Input {get;private set;}
    public static float DeltaTime {get;private set;}
    private bool _running = true;
    private RenderTarget2D _renderTarget2D;
    private Scene _currentScene;

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
        CM = new Content(Content);
        Input = new();

        // loading content
        CM.LoadFonts();
        CM.LoadTextures();
        CM.LoadSoundEffects();
        // setting resolution
        Resolution = new Vector2(1600, 900);
        _renderTarget2D = new(GraphicsDevice, (int)Resolution.X, (int)Resolution.Y);

        _currentScene = new MainScene(this);
    }

    protected override void Update(GameTime gameTime)
    {
        DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Input.SetCurrentState();
        if(!_running)
        {
            Exit();
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Shutdown();
        }
        _currentScene.Update();
        Input.SetPrevirousState();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        GraphicsDevice.SetRenderTarget(_renderTarget2D);

        // drawing logic here
        _currentScene.Draw();

        GraphicsDevice.SetRenderTarget(null);
        Batch.Begin();
        Batch.Draw(_renderTarget2D, new Rectangle(0, 0, (int)ScreenSize.X, (int)ScreenSize.Y), Color.White);
        Batch.End();
        base.Draw(gameTime);
    }
    public void Shutdown()
    {
        _running = false;
    }
    public void SetScene(Scene scene)
    {
        _currentScene = scene;
    }
}
