#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace ArenaGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch hudSpriteBatch;
        SpriteBatch backgroundSpriteBatch;
        Camera camera;
        KeyboardState keyBoardState = Keyboard.GetState();
        List<BackgroundScrollingLayer> layers;


        SharedVariables sharedVariables = SharedVariables.Instance;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            sharedVariables.Content = Content;
            sharedVariables.Graphics = GraphicsDevice;
            sharedVariables.initVariables();

            this.IsMouseVisible = true;



            Texture2D stars1 = Content.Load<Texture2D>("Backgrounds/stars1");
            layers = new List<BackgroundScrollingLayer> {
                { new BackgroundScrollingLayer(Content.Load<Texture2D>("Backgrounds/space"), new Rectangle(0, 0, 2048, 1536),30) },
                { new BackgroundScrollingLayer(stars1, new Rectangle(0, 0, 2560, 2560),10) },
                { new BackgroundScrollingLayer(stars1, new Rectangle(0, 0, 2560, 2560),5) },
                { new BackgroundScrollingLayer(Content.Load<Texture2D>("Backgrounds/stars2"), new Rectangle(0, 0, 2560, 2560),15) },
            };
            

            sharedVariables.Npcs.Add(new NPC(Content.Load<Texture2D>("Characters/knight"), new Vector2(400, 630), new Rectangle(350, 625, 200, 100), GraphicsDevice,Content));
            sharedVariables.Npcs.Add(new NPC(Content.Load<Texture2D>("Characters/warrior"), new Vector2(160, 900), new Rectangle(150, 800, 100, 200),GraphicsDevice,Content));
            sharedVariables.Npcs.Add(new NPC(Content.Load<Texture2D>("Characters/wizard"), new Vector2(450, 1050), new Rectangle(300, 900, 200, 190), GraphicsDevice,Content));

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Cursor myCursor = NativeMethods.LoadCustomCursor(@"Content\cursor.cur");
            Form winForm = (Form)Form.FromHandle(this.Window.Handle);
            winForm.Cursor = myCursor;


            spriteBatch = new SpriteBatch(GraphicsDevice);
            hudSpriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundSpriteBatch = new SpriteBatch(GraphicsDevice);

            camera = new Camera();

            sharedVariables.Hud.LoadContent(Content);
            sharedVariables.Hud.ShowHud = true;

            
            sharedVariables.TileMap.Generate(readMap("Maps/homeMap.txt", 66), 64);
            sharedVariables.FenceMap.Generate(readMap("Maps/fenceMap.txt", 66), 64);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            checkKeyInput();

            sharedVariables.Character.Update(gameTime);
            sharedVariables.Hud.Update(gameTime, sharedVariables.Character.X, sharedVariables.Character.Y, sharedVariables.Character.charStats.health);

            parallexScrolling();
            checkCollisionBetweenMapObjects();

            camera.Update(sharedVariables.Character.X, sharedVariables.Character.Y, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //npcs.Update(gameTime);
            foreach (NPC npc in sharedVariables.Npcs) { npc.Update(gameTime, new Rectangle((int)sharedVariables.Character.X,(int)sharedVariables.Character.Y, 64, 64)); }

            graphics.ApplyChanges();
            base.Update(gameTime);
        }

        int[,] readMap(string path, int length)
        {
            string[] fileLines = File.ReadAllLines(path);

            var lines = File.ReadAllLines(path);
            int[,] tileMap = new int[fileLines.Length, length];
            for (int i = 0; i < fileLines.Length; ++i)
            {
                var data = lines[i].Split(',').Select(c => Int32.Parse(c)).ToList();

                for (int j = 0; j < length; ++j)
                    tileMap[i, j] = data[j];
            }
            return tileMap;
        }

        void parallexScrolling()
        {
            foreach (BackgroundScrollingLayer layer in layers)
            {
                layer.Update((int)sharedVariables.Character.X, (int)sharedVariables.Character.Y);
            }

        }
        void checkCollisionBetweenMapObjects()
        {
            foreach (Tile tile in sharedVariables.FenceMap.Tiles)
            {
                sharedVariables.Character.Collision(tile.CollisionRectangle);
                foreach (CharacterEntityShootableProjectile proj in sharedVariables.Character.Projectiles)
                {
                    proj.bulletCollision(tile);
                }
                //1726 4107
            }
            Rectangle outOfBoundsRectangle = new Rectangle(0, 0, 4171, 1664);
            sharedVariables.Character.isOutOfBounds(outOfBoundsRectangle);
        }
        void checkKeyInput()
        {
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F11))
            {
                graphics.ToggleFullScreen();
            }
        }
        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            backgroundSpriteBatch.Begin();
            foreach(BackgroundScrollingLayer layer in layers) { layer.Draw(backgroundSpriteBatch); }
            backgroundSpriteBatch.End();


            spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null,
                camera.Transform);

            sharedVariables.TileMap.Draw(spriteBatch);
            sharedVariables.Character.Draw(spriteBatch);
            sharedVariables.FenceMap.Draw(spriteBatch);
            
            
            
            foreach(NPC npc in sharedVariables.Npcs) { npc.Draw(spriteBatch); }
            spriteBatch.End();

            hudSpriteBatch.Begin();
            sharedVariables.Hud.Draw(hudSpriteBatch);
            hudSpriteBatch.End();
            base.Draw(gameTime);
        }

    }
}