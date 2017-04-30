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
        GraphicsDevice graphics;
        public static ContentManager Content;
        public List<Tile> Tiles{get;set;}
        string tName;
        static private Texture2D characterBorder;
        public Map(string tileName, GraphicsDevice graphics)
        {
            tName = tileName;
            this.graphics = graphics;
            if(characterBorder == null)
            {
                characterBorder = new Texture2D(graphics, 64, 64);
                characterBorder.CreateBorder(1, Color.Red);
            }
            
            Tiles = new List<Tile>();
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
                        Tiles.Add(getCollidable(tName,number,x,y,size));
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in Tiles)
            {
                tile.Draw(spriteBatch);
                spriteBatch.Draw(characterBorder, tile.CollisionRectangle, Color.White);
            }
        }
        public Tile getCollidable(string tName, int number, int x, int y, int size)
        {
            string name = tName + number.ToString();
            switch (name)
            {
                case "Collidables1":
                    return new CollidableFence(Map.Content.Load<Texture2D>("Collidables/" + tName + number), new Rectangle(x * size, y * size, size, size));

                case "Collidables2":
                    return new CollidableTree(Map.Content.Load<Texture2D>("Collidables/" + tName + number), new Rectangle(x * size, y * size, size, size));

                case "Collidables3":
                    return new CollidableTreeBorderTall(Map.Content.Load<Texture2D>("Collidables/" + tName + number), new Rectangle(x * size, y * size, size, size));

                case "Collidables4":
                    return new CollidableTreeCherry(Map.Content.Load<Texture2D>("Collidables/" + tName + number), new Rectangle(x * size, y * size, size, size));

                case "Collidables5":
                    return new CollidableFenceVerLeft(Map.Content.Load<Texture2D>("Collidables/" + tName + number), new Rectangle(x * size, y * size, size, size));

                case "Collidables6":
                    return new CollidableFenceVerRight(Map.Content.Load<Texture2D>("Collidables/" + tName + number), new Rectangle(x * size, y * size, size, size));

                case "Tile1":
                    return new Tile(Map.Content.Load<Texture2D>("Tiles/" + tName + number), new Rectangle(x * size, y * size, size, size));

                case "Tile2":
                    return new Tile(Map.Content.Load<Texture2D>("Tiles/" + tName + number), new Rectangle(x * size, y * size, size, size));

            }
            return null;
        }
    }
}
