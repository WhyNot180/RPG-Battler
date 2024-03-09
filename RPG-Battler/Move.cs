using System;
using System.Collections.Generic;
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
            return Math.Log10(accuracy * baseAccuracy) - rand.NextDouble() * baseAccuracy + rand.Next() * baseAccuracy;
        }

        protected abstract int calculateDamage(Stats attackerStats, List<Stats> defenderStatsList);

        public virtual void attack(Stats attackerStats, List<Stats> defenderStatsList)
        {
            int damage = calculateDamage(attackerStats, defenderStatsList);
            defenderStatsList.First().HP -= damage;
        }

    }
}
