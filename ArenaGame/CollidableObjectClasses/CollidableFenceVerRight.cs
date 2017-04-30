using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    class CollidableFenceVerRight : Tile
    {
        public CollidableFenceVerRight(Texture2D Texture2d, Rectangle PictureRectangle)
        {
            this.Texture2d = Texture2d;
            this.PictureRectangle = PictureRectangle;
            this.CollisionRectangle = new Rectangle(PictureRectangle.X + (PictureRectangle.Width - 15) / 2, PictureRectangle.Y + PictureRectangle.Height / 2, 25, 64);
        }
    }
}

