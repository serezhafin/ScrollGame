using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ScrollGame
{
    class Bullets
    {
        public Texture2D bullet;
        public Rectangle bulletPosition;
        public bool isVisible;

        Menu menu;

        public Bullets(Texture2D bullet, Rectangle mainPosition)
        {
            this.bullet = bullet;
            isVisible = false;
            bulletPosition.X = mainPosition.Left + 25;
            bulletPosition.Y = mainPosition.Top;
            bulletPosition.Height = 18;
            bulletPosition.Width = 6;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bullet, bulletPosition, Color.White);
        }
    }
}
