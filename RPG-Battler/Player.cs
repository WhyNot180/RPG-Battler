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

        public Player(string name) 
        {
            numberOfPlayers++;
            this.Name = name;
            this.Stats = new Stats(100, 100, 30, 20, 25, 10, 15, 30);
        }

        public void load(ContentManager Content)
        {
            idleTextures = Content.Load<Texture2D>("player_idle");
            playerIdle = new AnimatedSprite(idleTextures, 1, 5, 2);
        }

        public void animate(GameTime gameTime)
        {
            int currentMilli = gameTime.TotalGameTime.Milliseconds;
            playerIdle.Update(currentMilli, 10);
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            playerIdle.Draw(_spriteBatch, position);
        }
    }
}