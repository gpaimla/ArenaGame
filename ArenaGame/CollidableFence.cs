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
    public class CollidableFence : Tile
    {
        public CollidableFence(Texture2D Texture2d, Rectangle PictureRectangle)
        {
            this.Texture2d = Texture2d;
            this.PictureRectangle = new Rectangle(PictureRectangle.X, PictureRectangle.Y, 64, 64);
            this.CollisionRectangle = new Rectangle(PictureRectangle.X - 32 + PictureRectangle.Width / 2, PictureRectangle.Y + PictureRectangle.Height / 2, 64, 32);     
        }
    }
}
