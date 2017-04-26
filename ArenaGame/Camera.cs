using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform;  }
        }

        private Vector2 center;
        private Viewport viewport;

        private float zoom = 1;

        public float X
        {
            get { return center.X; }
            set { center.X = value; }
        }

        public float Y
        {
            get { return center.Y; }
            set { center.Y = value; }
        }

        public float Zoom
        {
            get { return zoom;  }
            set { zoom = value; if (zoom < 0.1f) zoom = 0.1f; }
        }




        public  Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(float x, float y, int xOffset, int yOffset)
        {
            Vector2 position = new Vector2(x + 64 / 2 - xOffset / 2, y + 64 / 2 - yOffset / 2);
            center = new Vector2(position.X, position.Y);

            //if (position.X < viewport.Width / 2)
            //    center.X = viewport.Width / 2;
            //else if(position.X > xOffset - (viewport.Width / 2))
            //{
            //    center.X = xOffset - (viewport.Width / 2);
            //}
            //else {
            //    center.X = position.X;
            //}

            //if (position.Y < viewport.Height / 2)
            //    center.Y = viewport.Height / 2;
            //else if (position.Y > yOffset - (viewport.Height / 2))
            //{
            //    center.Y = yOffset - (viewport.Height / 2);
            //}
            //else
            //{
            //    center.Y = position.Y;
            //}


            //transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewport.Width / 2), -center.Y + (viewport.Height / 2), 0));
            //transform = Matrix.CreateTranslation(new Vector3(-center.X / 2, -center.Y / 2, 0)) *
            transform = Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0)) *
                                                 Matrix.CreateScale(new Vector3(Zoom, zoom, 0)); // * 
                                                 //Matrix.CreateTranslation(new Vector3(-viewport.Width / 2, -viewport.Height / 2, 0));
        }
    }
}
