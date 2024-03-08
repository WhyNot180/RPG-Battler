using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public class BloodBullet : Move
    {
        protected override int calculateDamage(Stats attackerStats, Stats defenderStats)
        {
            int damage = attackerStats.Damage;
            int defense = defenderStats.Defense;
            return Convert.ToInt32((damage - defense)*calculateSpread(attackerStats.Accuracy));
        }
    }
}
