using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{

    public sealed class SharedVariables
    {
        private static SharedVariables instance = null;
        private static readonly object padlock = new object();

        public CharacterEntity Character { get; set; }
        public Map TileMap { get; set; }
        public Map FenceMap { get; set; }
        public List<NPC> Npcs {get;set;}
        public HUD Hud { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDevice Graphics { get; set; }


        static bool called = false;
        SharedVariables()
        {
            

        }

        public static SharedVariables Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SharedVariables();
                    }
                    return instance;
                }
            }
        }
        public void initVariables()
        {
            if (!called)
            {
                FenceMap = new Map("Collidables");
                TileMap = new Map("Tile");
                Character = new CharacterEntity();
                Npcs = new List<NPC>();
                Hud = new HUD();

                called = true;
            }
            
        }
    }

    
}
