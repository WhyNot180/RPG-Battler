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
        protected AnimatedSprite idleAnimation;
        protected AnimatedSprite attackAnimation;
        protected AnimatedSprite hurtAnimation;
        protected AnimatedSprite deathAnimation;
        private int animationState = 0;
        public int AnimationState { 
            get { return animationState; } 
            set { 
                animationState = value;
                idleAnimation.Reset();
                attackAnimation.Reset();
                hurtAnimation.Reset();
                deathAnimation.Reset();
            } 
        }
        public Stats BaseStats {  get; set; }
        public abstract void passive();

        public void update(KeyboardState keyboardState)
        {

            if (keyboardState.IsKeyDown(Keys.D0)) 
            {
                AnimationState = 0;
            } else if (keyboardState.IsKeyDown(Keys.D1))
            {
                AnimationState = 1;
            } else if (keyboardState.IsKeyDown(Keys.D2))
            {
                AnimationState = 2;
            } else if (keyboardState.IsKeyDown(Keys.D3))
            {
                AnimationState = 3;
            }
        }

        public virtual void animate(int currentMilli)
        {
            switch (AnimationState)
            {
                case 0:
                    idleAnimation.Update(currentMilli, 10);
                    break;
                case 1:
                    attackAnimation.Update(currentMilli, 10);
                    break;
                case 2:
                    hurtAnimation.Update(currentMilli, 10);
                    break;
                case 3:
                    deathAnimation.Update(currentMilli, 10);
                    break;
            }
        }

        public virtual void draw(SpriteBatch spriteBatch, Vector2 position)
        {
            switch (AnimationState)
            {
                case 0:
                    idleAnimation.Draw(spriteBatch, position);
                    break;
                case 1:
                    attackAnimation.Draw(spriteBatch, position);
                    break;
                case 2:
                    hurtAnimation.Draw(spriteBatch, position);
                    break;
                case 3:
                    deathAnimation.Draw(spriteBatch, position);
                    break;
            }

        }

    }
}
