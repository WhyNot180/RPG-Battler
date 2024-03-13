using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public abstract class PlayerType
    {
        public Stats BaseStats {  get; set; }

        public AnimatedSprite IdleAnimation {  get; protected set; }
        public AnimatedSprite AttackAnimation { get; protected set; }
        public AnimatedSprite HurtAnimation { get; protected set; }
        public AnimatedSprite DeathAnimation { get; protected set; }


    }
}
