using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArenaGame
{
    class CollidableChestVertical : Tile
    {
        public CollidableChestVertical(Texture2D Texture2d, Rectangle PictureRectangle)
        {
            this.Texture2d = Texture2d;
            this.PictureRectangle = new Rectangle(PictureRectangle.X, PictureRectangle.Y, 64, 100);
            this.CollisionRectangle = new Rectangle(PictureRectangle.X, PictureRectangle.Y, 64, 100);
        }
    }
}