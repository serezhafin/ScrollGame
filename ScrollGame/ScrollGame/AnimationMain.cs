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
        Menu menu;

        Vector2 coordPosition;

        Texture2D main;

        Rectangle position;

        int frameWidth, frameHeight;
        public int FrameCount { get { return main.Width / frameWidth; } }

        int currentFrame, timeElasped, timeForFrame = 100;

        public AnimationMain(Rectangle rect, Texture2D texture, Game1 game, SpriteFont font)
        {
            this.position = rect;
            this.main = texture;
            this.game = game;
            frameWidth = 50;
            frameHeight = 50;

            coordPosition = new Vector2(20, 20);
            menu = new Menu(coordPosition, font);
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
            if (keyState.IsKeyDown(Keys.Left))
                position.X -= 5;
            if (keyState.IsKeyDown(Keys.Right))
                position.X += 5;
            if (keyState.IsKeyDown(Keys.Up))
                position.Y -= 5;
            if (keyState.IsKeyDown(Keys.Down))
                position.Y += 5;
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(frameHeight * currentFrame, 0, frameWidth, frameHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(main, position, sourceRect, Color.White);
            spriteBatch.End();
            menu.Draw(spriteBatch, "X: " + position.X + "\n" + "Y: " + position.Y);
        }
    }
}
