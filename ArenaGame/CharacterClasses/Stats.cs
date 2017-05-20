using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Stats
    {
        public int level { get; set; }
        public int health { get; set; }
        public int attack { get; set; }
        public int stamina { get; set; }
        public int armor { get; set; }
        public int attackRate { get; set; }

        public Stats(int level, int health, int attack, int stamina, int armor, int attackRate)
        {
            this.level = level;
            this.health = health;
            this.attack = attack;
            this.stamina = stamina;
            this.armor = armor;
            this.attackRate = attackRate;
        }
    }
}
