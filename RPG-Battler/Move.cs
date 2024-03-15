using System;

namespace RPG_Battler
{
    public abstract class Move
    {
        protected int cooldown;

        protected int specialPointsUse;

        /// <summary>
        /// Accuracy of move as a percentage (0.0 - 1.0).
        /// </summary>
        protected double baseAccuracy;

        protected int chargeTime;

        public string Name { get; protected set; }
        public string Description { get; protected set; }

        /// <summary>
        /// The associated animation.
        /// </summary>
        public Player.AnimationState Animation {  get; protected set; }

        /// <summary>
        /// Calculates the damage spread of an attack.
        /// </summary>
        /// <param name="accuracy">Accuracy stat of player using attack.</param>
        /// <returns></returns>
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
