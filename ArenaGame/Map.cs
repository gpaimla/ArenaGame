using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    class Map
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }

        private int width, height;
        private string tName;

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        

        public Map(string tileName, GraphicsDevice g) {
            tName = tileName;
            DrawBorder = false;
            this.g = g;
            

        }
        public Boolean DrawBorder
        {
            get;set;
        }
        private GraphicsDevice g;



        public void Generate(int[,] map, int size)
        {
            for(int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if(number > 0)
                    {
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size), tName,g));

                        width = (x + 1) * size;
                        height = (y + 1) * size;
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(CollisionTiles tile in collisionTiles)
            {

                tile.DrawBorder = DrawBorder;
                tile.Draw(spriteBatch);
            }
        }
    }
}
