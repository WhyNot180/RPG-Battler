using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RPG_Battler
{
    public class Game1 : Game
    {
        private enum GameState
        {
            FIGHT
        }

        private GameState _state;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private KeyboardState _keyboardState;
        private KeyboardState _previousKeyboardState;

        private int buttonIndex = 0;

        private List<Player> players = new List<Player>();

        private int currentPlayerTurn = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            players.Add(new Player("Bob", new Vector2(0,0)));
            players.Add(new Player("Jerry", new Vector2(30,0)));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            players.ForEach((player) => player.load(Content));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (_state)
            {
                case GameState.FIGHT:
                    Player currentPlayer = players.ElementAt(currentPlayerTurn);
                    Player enemyPlayer = players.ElementAt((currentPlayerTurn + 1) % 2);
                    selectButton(currentPlayer.MaxMoves);
                    selectMove(currentPlayer, enemyPlayer);
                    if (players.ElementAt(currentPlayerTurn).EndTurn)
                    {
                        currentPlayerTurn++;
                        enemyPlayer.onTurnStart();
                    }
                    if (currentPlayerTurn >= players.Count) currentPlayerTurn = 0;
                    break;
            }

            players.ForEach((player) => player.animate(gameTime));
            
            _previousKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            players.ForEach((player) => player.draw(_spriteBatch));

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void selectButton(int buttonCount)
        {
            if (_keyboardState.IsKeyDown(Keys.Right) && (_keyboardState.IsKeyDown(Keys.Right) != _previousKeyboardState.IsKeyDown(Keys.Right)))
            {
                buttonIndex++;
                if (buttonIndex >= buttonCount) buttonIndex = 0;

            }
            else if (_keyboardState.IsKeyDown(Keys.Left) && (_keyboardState.IsKeyDown(Keys.Left) != _previousKeyboardState.IsKeyDown(Keys.Left)))
            {
                buttonIndex--;
                if (buttonIndex == -1) buttonIndex = 0;
            }

        }

        private void selectMove(Player currentPlayer, Player enemyPlayer)
        {
            bool idle = currentPlayer.CurrentState == Player.AnimationState.IDLE;
            bool enterPressed = _keyboardState.IsKeyDown(Keys.Enter) && (_keyboardState.IsKeyDown(Keys.Enter) != _previousKeyboardState.IsKeyDown(Keys.Enter));

            if (enterPressed && idle)
            {
                currentPlayer.useCurrentSelectedAction(enemyPlayer, buttonIndex, Player.SelectableActions.ATTACK);
            }

        }
    }
}
