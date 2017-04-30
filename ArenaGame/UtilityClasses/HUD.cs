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
        private bool showHud;
        

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
            playerPosPosition.X = 10;
            playerPosPosition.Y = 10;
            gameTimePosition.X = 10;
            gameTimePosition.Y = 25;

            showHud = true;
        }

        public void LoadContent(ContentManager Content)
        {
            //04b08
            
            hudFont = Content.Load<SpriteFont>("font04b08");
        }

        //update

        public void Update(GameTime gametime)
        {

            playerPosVec = new Vector2(CharacterEntity.X, CharacterEntity.Y);
            playerPosTxt = "X: " + Math.Round(playerPosVec.X) + " Y: " + Math.Round(playerPosVec.Y);
            gameTimeTxt = "GameTime in S: " + gametime.TotalGameTime.TotalSeconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(showHud)
            {
                spriteBatch.DrawString(hudFont, playerPosTxt, playerPosPosition, Color.White);
                spriteBatch.DrawString(hudFont, gameTimeTxt, gameTimePosition, Color.White);
            }
        }
    }
}
