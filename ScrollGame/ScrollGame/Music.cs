using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;

namespace ScrollGame
{
    class Music
    {
        Song music;
        public Music(Song music)
        {
            this.music = music;
        }

        public void Play()
        {
            MediaPlayer.Play(music);
        }

        public void Volume()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Z))
                MediaPlayer.Volume -= 0.01f;
            if (keyState.IsKeyDown(Keys.X))
                MediaPlayer.Volume += 0.01f;
        }
    }
}
