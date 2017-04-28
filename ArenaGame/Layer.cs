using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArenaGame
{
    class Layer
    {
        public Scrolling scrolling;

        public Layer(Texture2D texture, Rectangle rectangle) {
            scrolling = new Scrolling(texture, rectangle);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                scrolling.Draw(spriteBatch);
        }
    }
}
