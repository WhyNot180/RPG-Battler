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

        protected AnimatedSprite idleAnimation;
        protected AnimatedSprite attackAnimation;
        protected AnimatedSprite hurtAnimation;
        protected AnimatedSprite deathAnimation;
        private AnimationState currentState = PlayerType.AnimationState.IDLE;
        public enum AnimationState
        {
            IDLE,
            ATTACK,
            HURT,
            DEATH
        }
        public AnimationState CurrentState { 
            get { return currentState; } 
            set {
                currentState = value;
                idleAnimation.Reset();
                attackAnimation.Reset();
                hurtAnimation.Reset();
                deathAnimation.Reset();
            } 
        }

        public void update(KeyboardState keyboardState)
        {

            if (keyboardState.IsKeyDown(Keys.D0)) 
            {
                CurrentState = AnimationState.IDLE;
            } else if (keyboardState.IsKeyDown(Keys.D1))
            {
                CurrentState = AnimationState.ATTACK;
            } else if (keyboardState.IsKeyDown(Keys.D2))
            {
                CurrentState = AnimationState.HURT;
            } else if (keyboardState.IsKeyDown(Keys.D3))
            {
                CurrentState = AnimationState.DEATH;
            }
        }

        public virtual void animate(int currentMilli)
        {
            switch (CurrentState)
            {
                case AnimationState.IDLE:
                    idleAnimation.Update(currentMilli, 10);
                    break;
                case AnimationState.ATTACK:
                    attackAnimation.Update(currentMilli, 10);
                    break;
                case AnimationState.HURT:
                    hurtAnimation.Update(currentMilli, 10);
                    break;
                case AnimationState.DEATH:
                    deathAnimation.Update(currentMilli, 10);
                    break;
            }
        }

        public virtual void draw(SpriteBatch spriteBatch, Vector2 position)
        {
            switch (CurrentState)
            {
                case AnimationState.IDLE:
                    idleAnimation.Draw(spriteBatch, position);
                    break;
                case AnimationState.ATTACK:
                    attackAnimation.Draw(spriteBatch, position);
                    break;
                case AnimationState.HURT:
                    hurtAnimation.Draw(spriteBatch, position);
                    break;
                case AnimationState.DEATH:
                    deathAnimation.Draw(spriteBatch, position);
                    break;
            }

        }
        public abstract void passive();

    }
}
