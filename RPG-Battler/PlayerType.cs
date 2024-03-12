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

        public virtual void animate(int currentMilli)
        {
            bool isFinished;
            switch (CurrentState)
            {
                case AnimationState.IDLE:
                    idleAnimation.Update(currentMilli, 10);
                    break;
                case AnimationState.ATTACK:
                    isFinished = attackAnimation.Update(currentMilli, 10);
                    if (isFinished) CurrentState = AnimationState.IDLE;
                    break;
                case AnimationState.HURT:
                    isFinished = hurtAnimation.Update(currentMilli, 10);
                    if (isFinished) CurrentState = AnimationState.IDLE;
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
