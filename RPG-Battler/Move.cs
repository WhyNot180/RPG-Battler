using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public abstract class Move
    {
        public string name;
        protected int cooldown;
        protected int specialPointsUse;
        protected int baseAccuracy;
        protected int chargeTime;

        protected virtual double calculateSpread(int accuracy)
        {
            Random rand = new Random();
            return Math.Log10(accuracy * baseAccuracy) - rand.NextDouble() * baseAccuracy + rand.Next() * baseAccuracy;
        }

        protected abstract int calculateDamage(Stats attackerStats, Stats defenderStats);

        public void attack(Stats attackerStats, Stats defenderStats)
        {
            int damage = calculateDamage(attackerStats, defenderStats);
            defenderStats.HP -= damage;
        }

    }
}
