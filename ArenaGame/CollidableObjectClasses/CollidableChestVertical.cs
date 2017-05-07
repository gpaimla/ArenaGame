using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArenaGame
{
    class CollidableChestVertical : Tile
    {
        public CollidableChestVertical(Texture2D Texture2d, Rectangle PictureRectangle)
        {
            this.Texture2d = Texture2d;
            this.PictureRectangle = PictureRectangle;
            this.CollisionRectangle = new Rectangle(PictureRectangle.X + (PictureRectangle.Width) / 2, PictureRectangle.Y + PictureRectangle.Height / 2, 64, 100);
        }
    }
}