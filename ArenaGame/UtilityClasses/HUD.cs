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
        GraphicsDevice graphics;

        private Vector2 gameTimePosition;
        private Vector2 playerPosVec;
        private Vector2 playerPosPosition;
        private SpriteFont hudFont;
        private string playerPosTxt;
        private string gameTimeTxt;
        public bool ShowHud { get; set; }

        //health bar
        Texture2D healthTexture;
        Rectangle healthRectangle;

        public HUD(GraphicsDevice graphics)
        {
            playerPosPosition = new Vector2(10, 10);
            gameTimePosition = new Vector2(10, 25);


            healthRectangle = new Rectangle(910, 485, 100, 8); //widht(100) should be replaced with player.health or something similar

            healthTexture = new Texture2D(graphics, 1, 1); 
            healthTexture.SetData(new Color[] { new Color(0, 255, 0) });


        }

        public void LoadContent(ContentManager Content)
        {
            hudFont = Content.Load<SpriteFont>("Courier New");
            
        }

        public void Update(GameTime gametime, float x, float y)
        {
            //healthRectangle = new Rectangle(50, 20, player.health, 15);
            playerPosVec = new Vector2(x, y);
            playerPosTxt = "X: " + Math.Round(playerPosVec.X) + " Y: " + Math.Round(playerPosVec.Y);
            gameTimeTxt = "GameTime in S: " + gametime.TotalGameTime.TotalSeconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(ShowHud)
            {
                spriteBatch.DrawString(hudFont, playerPosTxt, playerPosPosition, Color.White);
                spriteBatch.DrawString(hudFont, gameTimeTxt, gameTimePosition, Color.White);

                spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
            }
        }
    }
}
