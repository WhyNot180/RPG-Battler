using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public abstract class Move
    {
        protected int cooldown;
        protected int specialPointsUse;
        protected double baseAccuracy;
        protected int chargeTime;
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public PlayerType.AnimationState Animation {  get; protected set; }

        protected virtual double calculateSpread(int accuracy)
        {
            Random rand = new Random();
            return Math.Log10(accuracy * baseAccuracy) - rand.NextDouble() * baseAccuracy + rand.NextDouble() * baseAccuracy;
        }

        protected abstract int calculateDamage(Stats attackerStats, Stats defenderStats);

        public virtual void attack(Stats attackerStats, Stats defenderStats)
        {
            int damage = calculateDamage(attackerStats, defenderStats);
            defenderStats.HP -= damage;
        }

    }
}
