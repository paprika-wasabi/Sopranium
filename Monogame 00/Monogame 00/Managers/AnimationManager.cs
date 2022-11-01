﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame_00.Source.Engine;

namespace Monogame_00.Managers
{
    public class AnimationManager
    {
        private Animation mAnimation;

        private float mTimer;

        public Vector2 Position { get; set; }

        public AnimationManager(Animation animation)
        {
            mAnimation = animation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mAnimation.Texture,
                Position,
                new Rectangle(mAnimation.CurrentFrame * mAnimation.FrameWidth,
                    0,
                    mAnimation.FrameWidth,
                    mAnimation.FrameHeight),
                    Color.White);
        }
        public void Play(Animation animation)
        {
            if (mAnimation == animation)
            {
                return;
            }
            mAnimation = animation;
            mAnimation.CurrentFrame = 0;
            mTimer = 0;
        }

        public void Stop()
        {
            mTimer = 0f;

            mAnimation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            mTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (mTimer > mAnimation.FrameSpeed)
            {
                mTimer = 0f;

                mAnimation.CurrentFrame++;

                if (mAnimation.CurrentFrame >= mAnimation.FrameCount)
                {
                    mAnimation.CurrentFrame = 0;
                }
            }
        }
    }
}