using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleShooter.Engine;
using SimpleShooter.Engine.Textures;

namespace SimpleShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public textures game_textures;
        public World world;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            world.screensize = new Box<Vector2>(new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            world.Initialize();





        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.spriteBatch = _spriteBatch;
            Globals.Content = Content;
            game_textures = new textures();
            world = new World();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            world.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin(SpriteSortMode.FrontToBack);

            world.Draw();
            

            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
