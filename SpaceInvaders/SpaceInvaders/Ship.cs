using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace SpaceInvaders
{
    
    class Ship
    {
        Bullet bullet;
        SpriteBatch spriteBatch;
        KeyboardManager Km;
        Vector2 playerpos;
        const int playerVel = 100;
        Texture2D shipTexture;
        GraphicsDevice graphicsDevice;
        ContentManager content;
        SoundEffect bulletsound;
        AlienM alienM;
        


        public List<Bullet> bullets;
        
        public Ship(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.content = content;
            bullets = new List<Bullet>();
            this.Km = km;
            this.spriteBatch = spriteBatch;this.graphicsDevice = graphicsDevice;
            shipTexture = content.Load<Texture2D>("Character4"); 
            bulletsound = content.Load<SoundEffect>("laser");
            playerpos = new Vector2(0, shipTexture.Height/2);
            
        }

        public void Movement(GameTime gameTime)
        {
            
            foreach (Bullet b in bullets)
                b.Update(gameTime);

            if (Km.isKeyHeld(Keys.D))
            {
                playerpos = playerpos + new Vector2(1, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds * playerVel;
            }
            if (Km.isKeyHeld(Keys.A))
            {
                playerpos = playerpos + new Vector2(-1, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds * playerVel;
            }
            
        }

        
        public void shoot(GameTime gameTime)
        {
            if (Km.IsKeyPressed(Keys.Space))
            {
                bullets.Add(new Bullet(Km,  spriteBatch,  content, graphicsDevice,this));
                bulletsound.Play();
                
            }
        }
        public void Update(GameTime gameTime)
        {
            Movement(gameTime);
            shoot(gameTime);
            //removeB();

        }
        //public void  removeB()
        //{
        //    foreach(Bullet b1 in bullets.ToArray())
        //    {
        //        if (b1. <=0)
        //        {
        //            bullets.Remove(b1);
        //        }

        //    }
        //}
        
        public void Draw()
        {
            spriteBatch.Draw(shipTexture, ConvertToDrawPos(playerpos,shipTexture), Color.White);


            foreach(Bullet b in bullets)
                b.Draw();

        }

        Vector2 ConvertToDrawPos(Vector2 pos)
        {
            return new Vector2(graphicsDevice.Viewport.Width / 2 + pos.X, graphicsDevice.Viewport.Height - pos.Y);
        }

        Vector2 ConvertToDrawPos(Vector2 pos,Texture2D ship)
        {
            pos.X -= ship.Width / 2;
            pos.Y += ship.Height / 2;
            return ConvertToDrawPos(pos);


        }

        public Vector2 givePos()
        {
            return (new Vector2(playerpos.X, playerpos.Y));
        }
    }
}
