using System;

namespace RPG_Battler
{
    public class BloodBullet : Move
    {

        public BloodBullet() 
        {
            baseAccuracy = 0.5;
            Animation = Player.AnimationState.ATTACK;
            Name = "Blood Bullet";
            Description = "Fires a semi-accurate splotch of blood.";
        }

        protected override int calculateDamage(Stats attackerStats, Stats defenderStats)
        {
            int damage = attackerStats.Damage;
            int defense = defenderStats.Defense;
            return (int) Math.Round((damage - defense)*calculateSpread(attackerStats.Accuracy));
        }
    }
}
