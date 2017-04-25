using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class HUD
    {
        private int screenWidth, screenHeight;
        private Vector2 playerPosVec;
        private Vector2 playerPosPosition;
        private SpriteFont hudFont;
        private string playerPosTxt;
        private bool showHud;
        private GraphicsDevice graphicsDevice;

        public bool ShowHud
        {
            get { return showHud; }
            set { showHud = value; }
        }

        public Vector2 PlayerPos
        {
            get { return playerPosVec; }
            set { playerPosVec = value; }
        }

        public HUD()
        {
            playerPosVec.X = 0;
            playerPosVec.Y = 0;
            playerPosTxt = "X: " + playerPosVec.X + " Y: " + playerPosVec.Y;
            playerPosPosition.X = 10;
            playerPosPosition.Y = 10;

            showHud = true;

            screenWidth = 1920;
            screenHeight = 1080;
        }

        public void LoadContent(ContentManager Content)
        {
            //04b08
            
            hudFont = Content.Load<SpriteFont>("font04b08");
        }

        //update

        public void Update(GameTime gametime)
        {
            //KeyboardState keyState = Keyboard.GetState();
            //if (keyState.IsKeyDown(Keys.Tab))
            //{
            //    showHud = !showHud;
            //}

            playerPosVec = new Vector2(CharacterEntity.X, CharacterEntity.Y);
            playerPosTxt = "X: " + Math.Round(playerPosVec.X) + " Y: " + Math.Round(playerPosVec.Y);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(showHud)
            {
                spriteBatch.DrawString(hudFont, playerPosTxt, playerPosPosition, Color.White);
            }
        }
    }
}
