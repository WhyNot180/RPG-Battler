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

        protected abstract bool calculateHit(int accuracy);

        protected abstract bool calculateDamage(Stats stats);

        public abstract void attack(Stats stats);

    }
}
