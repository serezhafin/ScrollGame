using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ScrollGame
{
    class AnimationMain
    {
        Game1 game;
        

        Vector2 coordPosition;

        Texture2D main;

        public Rectangle position;

        int frameWidth, frameHeight;
        public int FrameCount { get { return main.Width / frameWidth; } }

        int currentFrame, timeElasped, timeForFrame = 100;

        public AnimationMain(Rectangle rect, Texture2D texture, Game1 game)
        {
            this.position = rect;
            this.main = texture;
            this.game = game;
            frameWidth = 50;
            frameHeight = 50;

            coordPosition = new Vector2(20, 20);
           
        }

        public void Update(GameTime gameTime)
        {
            Controls();
            timeElasped += gameTime.ElapsedGameTime.Milliseconds;
            if (timeElasped > timeForFrame)
            {
                timeElasped = 0;
                currentFrame = (currentFrame + 1) % FrameCount;
            }
        }

        public void Controls()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Left) && position.Left+10 >0)
                position.X -= 9;
            if (keyState.IsKeyDown(Keys.Right) && position.Right-10 < game.GraphicsDevice.Viewport.Width)
                position.X += 9;
            if (keyState.IsKeyDown(Keys.Up) && position.Top > 0)
                position.Y -= 5;
            if (keyState.IsKeyDown(Keys.Down) && position.Bottom < game.GraphicsDevice.Viewport.Height)
                position.Y += 5;
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(frameHeight * currentFrame, 0, frameWidth, frameHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(main, position, sourceRect, Color.White);
            spriteBatch.End();
        }
    }
}
