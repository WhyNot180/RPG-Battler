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

        private int currentPlayerTurn = 0;
        private Player currentPlayer;
        private Player enemyPlayer;

        public Combat(List<Player> players) 
        {
            
        }

        public void update()
        {
            
        }

        private void selectMove(Player currentPlayer, Player selectedPlayer, int buttonIndex)
        {
            bool idle = currentPlayer.CurrentState == Player.AnimationState.IDLE;
            bool enterPressed = Game1._keyboardState.IsKeyDown(Keys.Enter) && (Game1._keyboardState.IsKeyDown(Keys.Enter) != Game1._previousKeyboardState.IsKeyDown(Keys.Enter));

            if (enterPressed && idle)
            {
                currentPlayer.useCurrentSelectedAction(selectedPlayer, buttonIndex, Player.SelectableActions.ATTACK);
            }

        }
    }
}
