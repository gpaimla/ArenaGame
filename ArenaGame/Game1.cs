#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace WalkingGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        CharacterEntity character;
        KeyboardState keyBoardState = Keyboard.GetState();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;  // set this value to the desired height of your window
            graphics.IsFullScreen = true;
            
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;

            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            character = new CharacterEntity(this.GraphicsDevice);

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            character.Update(gameTime);
            base.Update(gameTime);

            //if (keyBoardState.IsKeyDown(Keys.F11))
            //{
            //    this.graphics.IsFullScreen = true;
            //    this.graphics.ToggleFullScreen();
            //    this.graphics.ApplyChanges();
            //}

                if (Keyboard.GetState().IsKeyDown(Keys.F11))
                {
                    if (graphics.IsFullScreen)
                    {
                        graphics.PreferredBackBufferWidth = 1280;
                        graphics.PreferredBackBufferHeight = 720;
                    }
                    else
                    {
                        graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; // set this value to the desired width of your window
                        graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                    }
                    graphics.ToggleFullScreen();
                }
                graphics.ApplyChanges();
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // We'll start all of our drawing here:
            spriteBatch.Begin();

            // Now we can do any entity rendering:
            character.Draw(spriteBatch);
            // End renders all sprites to the screen:
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}