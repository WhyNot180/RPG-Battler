using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace RPG_Battler
{
    public class Game : Microsoft.Xna.Framework.Game
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
        private MouseState _mouseState;

        private List<Player> players = new List<Player>();

        private Combat combat;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            players.Add(new Player("Bob", new Vector2(0,0), false));
            players.Add(new Player("Jerry", new Vector2(-500,0), true));

            combat = new Combat(players);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            players.ForEach((player) => player.Load(Content));

            combat.Load(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _previousKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();

            switch (_state)
            {
                case GameState.FIGHT:
                    combat.Update(_mouseState);
                    break;
            }

            players.ForEach((player) => player.Animate(gameTime));
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            players.ForEach((player) => player.Draw(_spriteBatch));

            switch (_state)
            {
                case GameState.FIGHT:
                    combat.Draw(_spriteBatch);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
