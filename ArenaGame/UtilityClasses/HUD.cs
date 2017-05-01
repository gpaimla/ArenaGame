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
        private Vector2 gameTimePosition;
        private Vector2 playerPosVec;
        private Vector2 playerPosPosition;
        private SpriteFont hudFont;
        private string playerPosTxt;
        private string gameTimeTxt;
        public bool ShowHud { get; set; }


        public HUD()
        {
            playerPosPosition = new Vector2(10, 10);
            gameTimePosition = new Vector2(10, 25);

        }

        public void LoadContent(ContentManager Content)
        {
            hudFont = Content.Load<SpriteFont>("font04b08");
        }

        public void Update(GameTime gametime, float x, float y)
        {

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
            }
        }
    }
}
