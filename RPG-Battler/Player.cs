using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;

namespace RPG_Battler
{
    public class Player
    {
        private Vector2 position = new Vector2(0,0);
        private static int numberOfPlayers = 0;
        public string Name { get; }
        public Stats Stats { get; set; }
        private AnimatedSprite playerIdle;
        private Texture2D idleTextures;
        private Vampire vampire;

        public Player(string name) 
        {
            numberOfPlayers++;
            this.Name = name;
            this.Stats = new Stats(100, 100, 30, 20, 25, 10, 15, 30);
        }

        public void load(ContentManager Content)
        {
            vampire = new Vampire(Content);
        }

        public void update(KeyboardState keyboardState)
        {
            vampire.update(keyboardState);
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