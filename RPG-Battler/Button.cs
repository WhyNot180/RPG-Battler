using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public class Button : ISelectable
    {
        public Vector2 position;
        public Vector2 size;
        private Texture2D texture;
        private Color colorOnSelect;
        private Action onActivate;

        public bool Selected {  get; set; }

        public Button(Vector2 position, Vector2 size, Texture2D texture, Color colorOnSelect, Action onActivate) 
        {
            this.position = position;
            this.size = size;
            this.texture = texture;
            this.colorOnSelect = colorOnSelect;
            this.onActivate = onActivate;
        }

        public void Update(MouseState mouseState)
        {
            if (inButton(mouseState))
            {
                Selected = true;
            } else
            {
                Selected = false;
            }

            onClick(mouseState);
        }

        private bool inButton(MouseState mouseState)
        {
            return mouseState.X < position.X + texture.Width*size.X && 
                mouseState.X > position.X && 
                mouseState.Y < position.Y + texture.Height*size.Y &&
                mouseState.Y > position.Y;
        }

        private void onClick(MouseState mouseState)
        {
            if (inButton(mouseState) && mouseState.LeftButton == ButtonState.Pressed)
            {
                onActivate();
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, position, null, Selected ? colorOnSelect : Color.White, 0, position, size, SpriteEffects.None, 0);
        }
    }
}
