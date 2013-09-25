using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ScrollGame
{
    class EnemyAnimation
    {
        Texture2D enemy;
        public Rectangle position;
        public bool isVisible;

        int frameWidth, frameHeight;
        public int FrameCount { get { return enemy.Width / frameWidth; } }

        int currentFrame, timeElasped, timeForFrame = 100;

        public EnemyAnimation(Texture2D enemy, Rectangle position)
        {
            this.enemy = enemy;
            this.position = position;
            frameHeight = 50;
            frameWidth = 50;
        }

        public void Update(GameTime gameTime)
        {
            timeElasped += gameTime.ElapsedGameTime.Milliseconds;
            if (timeElasped > timeForFrame)
            {
                timeElasped = 0;
                currentFrame = (currentFrame + 1) % FrameCount;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(frameHeight * currentFrame, 0, frameWidth, frameHeight);
            
            spriteBatch.Draw(enemy, position, sourceRect, Color.White);
            
        }
    }
}
