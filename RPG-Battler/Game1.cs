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

        internal static KeyboardState _keyboardState;
        internal static KeyboardState _previousKeyboardState;
        internal static MouseState _mouseState;

        private List<Player> players = new List<Player>();

        private Combat combat;

        public Game1()
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
