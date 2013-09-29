using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ScrollGame
{
    class Background
    {
        public Texture2D bckg;
        public Rectangle position;

        private Vector2 screenpos, origin, texturesize;
        private int screenheight;



        public Background(Texture2D bckg, Rectangle position, int height, int width)
        {
            this.bckg = bckg;
            this.position = position;
            screenheight = height;
            int screenwidth = width;
            origin = new Vector2(bckg.Width / 2, 0);
            screenpos = new Vector2(screenwidth / 2, screenheight / 2);
            texturesize = new Vector2(0, bckg.Height);
        }

        public void Update()
        {
            screenpos.Y += 4;
            screenpos.Y = screenpos.Y % bckg.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (screenpos.Y < screenheight)
            {
                spriteBatch.Draw(bckg, screenpos, null,
                     Color.White, 0, origin, 1, SpriteEffects.None, 0f);
            }

            // Рисуем второй бэк
            spriteBatch.Draw(bckg, screenpos - texturesize, null,
                 Color.White, 0, origin, 1, SpriteEffects.None, 0f);            
        }
    }
}
