using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ScrollGame
{
    class Menu
    {
        Game1 game;
        SpriteFont font;

        Vector2 position;

        public Menu(Vector2 position, SpriteFont sprite)
        {
            this.position = position;
            this.font = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, string toOut)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, toOut, position, Color.Red);
            spriteBatch.End();
        }

    }
}
