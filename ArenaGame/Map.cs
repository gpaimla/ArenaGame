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
    public class Map
    {
        CollidablesHolder collidablesHolder;
        public static ContentManager Content;
        public List<Tile> CollisionTiles{get;set;}
        string tName;
        public Map(string tileName)
        {
            tName = tileName;
            collidablesHolder = new CollidablesHolder();
            CollisionTiles = new List<Tile>();
        }
        
        public void Generate(int[,] map, int size)
        {

            for(int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if(number > 0)
                    {
                        CollisionTiles.Add(collidablesHolder.getCollidable(tName,number,x,y,size));
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in CollisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
    class CollidablesHolder
    {
        private Dictionary<int, Tile> allCollidableTiles = new Dictionary<int, Tile>();
        public CollidablesHolder()
        {

        }
        public Tile getCollidable(string tName, int number, int x, int y, int size)
        {
            string name = tName + number.ToString();
            switch (name)
            {
                case "Fence1":
                    return new CollidableFence(Map.Content.Load<Texture2D>(tName + number), new Rectangle(x * size, y * size, size, size));

                case "Fence2":
                    return  new CollidableTree(Map.Content.Load<Texture2D>(tName + number), new Rectangle(x * size, y * size, size, size));

                case "Fence3":
                    return new CollidableTreeBorderTall(Map.Content.Load<Texture2D>(tName + number), new Rectangle(x * size, y * size, size, size));

                case "Fence4":
                    return new CollidableTreeCherry(Map.Content.Load<Texture2D>(tName + number), new Rectangle(x * size, y * size, size, size));
                    

                case "Tile1":
                    return new Tile(Map.Content.Load<Texture2D>(tName + number), new Rectangle(x * size, y * size, size, size));

                case "Tile2":
                    return new Tile(Map.Content.Load<Texture2D>(tName + number), new Rectangle(x * size, y * size, size, size));

            }
            return null;
        }

    }
}
