using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;

namespace RPG_Battler
{
    public class Player 
    {
        public enum SelectableActions
        {
            IDLE,
            ATTACK  
        }

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
        }

        public void animate(GameTime gameTime)
        {
            int currentMilli = gameTime.TotalGameTime.Milliseconds;
            playerType.animate(currentMilli);
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            playerType.draw(_spriteBatch, position);
        }

        public void useCurrentSelectedAction(Player player, int buttonIndex, SelectableActions action)
        {
            switch (action)
            {
                case SelectableActions.ATTACK:
                    playerMoves.ElementAt(buttonIndex).attack(Stats, player.Stats);
                    playerType.CurrentState = PlayerType.AnimationState.ATTACK;
                    player.playerType.CurrentState = PlayerType.AnimationState.HURT;

                    // TODO: Figure out a way to set this after animations finish
                    endTurn = true;

                    break;
            }
            
        }
    }
}