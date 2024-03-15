using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace RPG_Battler
{
    public class Combat
    {

        private int currentTurn = 0;

        private List<Player> players;
        private Player currentPlayer;
        private Player enemyPlayer;
        private List<Button> currentPlayerButtons = new List<Button>();
        private Texture2D buttonTexture;

        public Combat(List<Player> participatingPlayers) 
        {
            players = participatingPlayers;

            // Temporary until enemy selection is implemented
            // First player should always be the one with the highest speed
            currentPlayer = players[0];
            enemyPlayer = players[1];
        }

        public void Load(GraphicsDevice graphicsDevice)
        {
            buttonTexture = new Texture2D(graphicsDevice, 1, 1);
            buttonTexture.SetData(new Color[] { Color.DarkSlateGray });
            createMoveButtons();
        }

        private void newTurn()
        {
            currentTurn++;
            currentPlayer = players.ElementAt(currentTurn % players.Count);
            // Temporary until enemy selection is implemented
            enemyPlayer = players.ElementAt((currentTurn + 1) % players.Count);
            currentPlayer.onTurnStart();
            currentPlayerButtons.Clear();
            createMoveButtons();
        }

        public void Update(MouseState mouseState)
        {
            if (!currentPlayer.IsAnimating)
            {
                currentPlayerButtons.ForEach(button => button.Update(mouseState));
            }

            // Won't work in an else if because IsAnimating switches too fast
            if (currentPlayer.EndTurn)
            {
                newTurn();
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            currentPlayerButtons.ForEach(button => button.Draw(_spriteBatch));
        }

        private void createMoveButtons()
        {
            int buttonWidth = 200;
            int buttonHeight = 100;
            for (int j = 0; j < currentPlayer.MaxMoves; j++)
            {
                currentPlayerButtons.Add(new Button(new Vector2(j * buttonWidth,380), 
                    new Vector2(buttonWidth, buttonHeight), buttonTexture, Color.White, Color.LightSlateGray, 
                    () => currentPlayer.useCurrentSelectedAction(enemyPlayer, j-1, Player.SelectableActions.ATTACK)));
            }
        }
    }
}
