using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ScrollGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Системное
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Элементы
        SpriteFont font;
        Texture2D main;
        Texture2D enemy;
        Texture2D bckg;
        Texture2D bulletTexture;
        Song song;

        // Положение главного героя
        int mainX, mainY;
        // Положение противника
        int enemyX, enemyY;

        // Системная информация
        bool isShowInformation = false;

        // Подгрузка классов
        Random rand;
        KeyboardState pastKey;
        KeyboardState pastKey2;
        AnimationMain MainAnimation;
        List<Bullets> bullets = new List<Bullets>();
        List<EnemyAnimation> Enemies = new List<EnemyAnimation>();
        Background scrolling1;
       // Music Music;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            mainX = 300;
            mainY = 300;

            enemyX = 100;
            enemyY = 100;

            this.Components.Add(new FPSCounter(this));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // СпрайтБатч
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Загрузка контента
            font = Content.Load<SpriteFont>("SpriteFont1");
            main = Content.Load<Texture2D>("main");
            enemy = Content.Load<Texture2D>("enemy1");
            song = Content.Load<Song>("music");
            bckg = Content.Load<Texture2D>("background");
            bulletTexture = Content.Load<Texture2D>("bullet");
            

            // Создание объектов класса
            rand = new Random();
            MainAnimation = new AnimationMain(new Rectangle(mainX, mainY, 50, 50), main, this);
            scrolling1 = new Background(bckg, new Rectangle(0, 0, 800, 500), GraphicsDevice.Viewport.Height, GraphicsDevice.Viewport.Width);
            //Music = new Music(song); Music.Play();

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && pastKey.IsKeyUp(Keys.Space))
                Shoot();
            if (Enemies.Count < 5)
                EnemyLaunch();

            pastKey = Keyboard.GetState();

            UpdateBullets();
            UpdateEnemies();

            MainAnimation.Update(gameTime);

            foreach (EnemyAnimation enemy in Enemies)
                enemy.Update(gameTime);

            
            scrolling1.Update();
            
           // Music.Volume();

            base.Update(gameTime);
        }

        public void UpdateEnemies()
        {
            foreach (EnemyAnimation enemy in Enemies)
            {
                enemy.position.Y += 3;
                if (enemy.position.Y > GraphicsDevice.Viewport.Height)
                    enemy.isVisible = false;
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                if (!Enemies[i].isVisible)
                {
                    Enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        public void EnemyLaunch()
        {
            EnemyAnimation newEnemy = new EnemyAnimation(enemy, new Rectangle(rand.Next(800), (rand.Next(200)-200), 50, 50));
            newEnemy.isVisible = true;

            if (Enemies.Count < 5)
                Enemies.Add(newEnemy);
        }

        public void UpdateBullets()
        {
            foreach (Bullets bullet in bullets)
            {
                bullet.bulletPosition.Y -= 4;
                if (Math.Abs(bullet.bulletPosition.Y - mainY) > 500)
                    bullet.isVisible = false;
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shoot()
        {
            Bullets newBullet = new Bullets(bulletTexture, new Rectangle(MainAnimation.position.X, MainAnimation.position.Y, 50, 50));
            newBullet.isVisible = true;

            
            if (bullets.Count < 20)
                bullets.Add(newBullet);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            scrolling1.Draw(spriteBatch);
            
            foreach (Bullets bullet in bullets)
                bullet.Draw(spriteBatch);

            foreach (EnemyAnimation enemy in Enemies)
                enemy.Draw(spriteBatch);

            spriteBatch.End();


            MainAnimation.Draw(spriteBatch);

            Information();

            base.Draw(gameTime);
        }

        void Information()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.I) && pastKey2.IsKeyUp(Keys.I))
                isShowInformation = !isShowInformation;

            pastKey2 = Keyboard.GetState();

            if (isShowInformation)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Nubmer of bullets: " + bullets.Count, new Vector2(GraphicsDevice.Viewport.Width-150, GraphicsDevice.Viewport.Height-85), Color.White);
                spriteBatch.End();
            }
        }
    }
}
