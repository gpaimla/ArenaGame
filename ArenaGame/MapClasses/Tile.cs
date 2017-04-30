using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Tile
    {
        public Texture2D Texture2d { get; set; }
        public Rectangle PictureRectangle { get; set; }
        public Rectangle CollisionRectangle { get; set; }


        public  Tile(Texture2D Texture2d, Rectangle PictureRectangle)
        {
            this.Texture2d = Texture2d;
            this.PictureRectangle = PictureRectangle;
        }
        public Tile()
        {
            
        }
      
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture2d, PictureRectangle, Color.White);
        }
    }
}
