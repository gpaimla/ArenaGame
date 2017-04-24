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
    class Tiles
    {


        protected Texture2D texture;
        private Texture2D square;
        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }
        static protected GraphicsDevice gd;

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }
        public Boolean DrawBorder
        {
            get; set;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(texture, rectangle, Color.White);
            if (DrawBorder)
            {
                square = new Texture2D(gd, rectangle.Width, rectangle.Height);
                square.CreateBorder(1, Color.Red);
                spriteBatch.Draw(square, new Vector2(rectangle.X, rectangle.Y), Color.White);
            }
        }

    }

    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle, string tName, GraphicsDevice g)
        {
            gd = g;
            texture = Content.Load<Texture2D>(tName + i);
            this.Rectangle = newRectangle;
        }
    }
     
}
