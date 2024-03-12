using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace RPG_Battler
{
    public class Player 
    {
        public enum SelectableActions
        {
            IDLE,
            ATTACK  
        }

        protected AnimatedSprite idleAnimation;
        protected AnimatedSprite attackAnimation;
        protected AnimatedSprite hurtAnimation;
        protected AnimatedSprite deathAnimation;

        private AnimationState currentState = AnimationState.IDLE;
        public enum AnimationState
        {
            IDLE,
            ATTACK,
            HURT,
            DEATH
        }
        public AnimationState CurrentState
        {
            get { return currentState; }
            set
            {
                currentState = value;
                idleAnimation.Reset();
                attackAnimation.Reset();
                hurtAnimation.Reset();
                deathAnimation.Reset();
            }
        }
        public AnimationState turnStartState = AnimationState.IDLE;

        private Vector2 position;

        public string Name { get; }

        public Stats Stats { get; set; }

        private PlayerType playerType;

        private List<Move> playerMoves = new List<Move> {new BloodBullet() };

        public int MaxMoves { get; private set; }

        private bool endTurn = false;

        public bool EndTurn
        {
            get
            {
                bool isTurnEnd = endTurn;
                // Reset EndTurn when called
                endTurn = false;
                return isTurnEnd;
            }
        }

        public Player(string name, Vector2 position) 
        {
            this.Name = name;
            MaxMoves = playerMoves.Count;
            this.position = position;
        }

        public void load(ContentManager Content)
        {
            playerType = new Vampire(Content);
            this.Stats = playerType.BaseStats;
            idleAnimation = playerType.IdleAnimation;
            attackAnimation = playerType.AttackAnimation;
            hurtAnimation = playerType.HurtAnimation;
            deathAnimation = playerType.DeathAnimation;
        }

        public void animate(GameTime gameTime)
        {
            int currentMilli = gameTime.TotalGameTime.Milliseconds;
            animatePlayerType(currentMilli);
        }

        private void animatePlayerType(int currentMilli)
        {
            bool isFinished = false;
            switch (CurrentState)
            {
                case AnimationState.IDLE:
                    idleAnimation.Update(currentMilli, 10);
                    break;
                case AnimationState.ATTACK:
                    isFinished = attackAnimation.Update(currentMilli, 10);
                    if (isFinished) 
                    { 
                        CurrentState = AnimationState.IDLE;
                        endTurn = true;
                    }
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

        public void draw(SpriteBatch spriteBatch)
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

        public void useCurrentSelectedAction(Player player, int buttonIndex, SelectableActions action)
        {
            switch (action)
            {
                case SelectableActions.ATTACK:
                    playerMoves.ElementAt(buttonIndex).attack(Stats, player.Stats);
                    CurrentState = AnimationState.ATTACK;
                    player.turnStartState = AnimationState.HURT;
                    break;
            }
            
        }

        public void onTurnStart()
        {
            CurrentState = turnStartState;
        }
    }
}