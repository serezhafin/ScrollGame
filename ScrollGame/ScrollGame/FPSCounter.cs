using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ScrollGame
{
    class FPSCounter : DrawableGameComponent
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        KeyboardState pastKey;
        bool isShowInformation;

        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        public FPSCounter(Game game)
            : base(game)
        {
            content = new ContentManager(game.Services);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("Content\\SpriteFont1");
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            frameCounter++;

            base.Draw(gameTime);

            Information();
        }

        void Information()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.I) && pastKey.IsKeyUp(Keys.I))
                isShowInformation = !isShowInformation;

            pastKey = Keyboard.GetState();

            if (isShowInformation)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, "Fps: " + frameRate, new Vector2(GraphicsDevice.Viewport.Width - 150, GraphicsDevice.Viewport.Height - 100), Color.White);
                spriteBatch.End();
            }
        }
    }
}
