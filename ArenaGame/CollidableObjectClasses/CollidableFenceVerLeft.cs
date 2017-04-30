using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ArenaGame
{
    public class CollidableFenceVerLeft : Tile
    {
        public CollidableFenceVerLeft(Texture2D Texture2d, Rectangle PictureRectangle)
        {
            this.Texture2d = Texture2d;
            this.PictureRectangle = PictureRectangle;
            this.CollisionRectangle = new Rectangle(PictureRectangle.X + (PictureRectangle.Width - 15) / 2, PictureRectangle.Y + PictureRectangle.Height / 2, 25, 64);
        }
    }
}
