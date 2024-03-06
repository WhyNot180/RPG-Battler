using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Battler
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public float Scale {  get; set; }
        public AnimatedSprite(Texture2D texture, int rows, int columns, float scale)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            Scale = scale;
        }
        public void Update(int currentMilli, double fps)
        {
            if (currentMilli % (1/fps * 1000) == 0) 
                currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, location, sourceRectangle, Color.White, 0, new Vector2(0,0), Scale, SpriteEffects.None, 0);
        }
    }
}
