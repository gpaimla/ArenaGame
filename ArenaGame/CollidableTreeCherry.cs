using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    class CollidableTreeCherry : Tile
    {
        public CollidableTreeCherry(Texture2D Texture2d, Rectangle PictureRectangle)
        {
            this.Texture2d = Texture2d;
            this.PictureRectangle = new Rectangle(PictureRectangle.X - 140, PictureRectangle.Y - 175, 292, 329);
            this.CollisionRectangle = new Rectangle(PictureRectangle.X + 16, PictureRectangle.Y + PictureRectangle.Height / 2 + 61, 53, 15);

        }
    }
}
