using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public class BloodBullet : Move
    {

        public BloodBullet() 
        {
            baseAccuracy = 0.5;
            Animation = PlayerType.AnimationState.ATTACK;
        }

        protected override int calculateDamage(Stats attackerStats, List<Stats> defenderStats)
        {
            int damage = attackerStats.Damage;
            int defense = defenderStats.First().Defense;
            return Convert.ToInt32((damage - defense)*calculateSpread(attackerStats.Accuracy));
        }
    }
}
