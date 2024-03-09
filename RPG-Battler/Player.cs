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
        private Vector2 position = new Vector2(0,0);
        public string Name { get; }
        public Stats Stats { get; set; }
        private Stats testStats = new Stats(100, 100, 30, 20, 25, 10, 15, 30);
        private List<Stats> testStatsList = new List<Stats>();
        private Vampire vampire;
        private int moveIndex = 0;
        private List<Move> playerMoves = new List<Move> {new BloodBullet() };

        public Player(string name) 
        {
            this.Name = name;
        }

        public void load(ContentManager Content)
        {
            vampire = new Vampire(Content);
            this.Stats = vampire.BaseStats;
            testStatsList.Add(testStats);
        }

        private KeyboardState pastState = Keyboard.GetState();
        public void update(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Up) && (keyboardState.IsKeyDown(Keys.Up) != pastState.IsKeyDown(Keys.Up)))
            {
                moveIndex++;
                if (moveIndex == playerMoves.Count) moveIndex = 0;

            } else if (keyboardState.IsKeyDown(Keys.Down) && (keyboardState.IsKeyDown(Keys.Down) != pastState.IsKeyDown(Keys.Down)))
            {
                moveIndex--;
                if (moveIndex == -1) moveIndex = 0;
            }

            if (keyboardState.IsKeyDown(Keys.Enter) && (keyboardState.IsKeyDown(Keys.Enter) != pastState.IsKeyDown(Keys.Enter))) 
            {
                Move move = playerMoves.ElementAt(moveIndex);
                move.attack(Stats, testStatsList);
                vampire.CurrentState = move.Animation;
            }
            pastState = keyboardState;
        }

        public void animate(GameTime gameTime)
        {
            int currentMilli = gameTime.TotalGameTime.Milliseconds;
            vampire.animate(currentMilli);
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            vampire.draw(_spriteBatch, position);
        }
    }
}