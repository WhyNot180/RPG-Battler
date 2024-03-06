using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public abstract class PlayerType
    {
        public Stats Stats {  get; set; }
        public abstract void passive();

        public PlayerType(Stats stats)
        {
            Stats = new Stats(stats);
        }

    }
}
