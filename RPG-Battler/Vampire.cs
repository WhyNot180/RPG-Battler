using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public class Vampire : PlayerType
    {

        public Vampire(ContentManager Content)
        {
            BaseStats = new Stats(70, 150, 50, 50, 30, 40, 40, 40);
            IdleAnimation = new AnimatedSprite(Content.Load<Texture2D>("vampire_idle"), 1, 5, 2);
            AttackAnimation = new AnimatedSprite(Content.Load<Texture2D>("vampire_attack"), 1, 6, 2);
            HurtAnimation = new AnimatedSprite(Content.Load<Texture2D>("vampire_hurt"), 1, 2, 2);
            DeathAnimation = new AnimatedSprite(Content.Load<Texture2D>("vampire_death"), 1, 8, 2);
        }

        public override void passive()
        {
            Console.WriteLine("Hello!");
        }
    }
}
