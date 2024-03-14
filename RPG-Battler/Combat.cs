using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public class Combat
    {

        private int currentTurn = 0;

        private List<Player> players;
        private Player currentPlayer;
        private Player enemyPlayer;

        public Combat(List<Player> participatingPlayers) 
        {
            players = participatingPlayers;

            // Temporary until enemy selection is implemented
            // First player should always be the one with the highest speed
            currentPlayer = players[0];
            enemyPlayer = players[1];
        }

        private void newTurn()
        {
            currentTurn++;
            currentPlayer = players.ElementAt(currentTurn % players.Count);
            // Temporary until enemy selection is implemented
            enemyPlayer = players.ElementAt((currentTurn + 1) % players.Count);
            currentPlayer.onTurnStart();
        }

        public void update()
        {
            if (!currentPlayer.IsAnimating)
            {
                selectButton(currentPlayer.MaxMoves);
                selectMove(currentPlayer, enemyPlayer);
                
            } else if (currentPlayer.EndTurn)
            
            {
                newTurn();
            }
        }

        private void selectMove(Player currentPlayer, Player selectedPlayer, int buttonIndex)
        {
            bool enterPressed = Game1._keyboardState.IsKeyDown(Keys.Enter) && !Game1._previousKeyboardState.IsKeyDown(Keys.Enter);

            if (enterPressed)
            {
                currentPlayer.useCurrentSelectedAction(selectedPlayer, buttonIndex, Player.SelectableActions.ATTACK);
            }

        }
    }
}
