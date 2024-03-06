using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG_Battler
{
    public class Player
    {
        private Vector2 position = new Vector2(0,0);
        private static int numberOfPlayers = 0;
        public string Name { get; }
        public Stats Stats { get; set; }

        public Player(string name) 
        {
            numberOfPlayers++;
            this.Name = name;
            this.Stats = new Stats(100, 100, 30, 20, 25, 10, 15, 30);
        }

        public void draw(SpriteBatch _spriteBatch)
        {
        }
    }
}