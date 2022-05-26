using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SpaceInvaders
{
    class Alien
    {
        SpriteBatch spriteBatch;
        Texture2D alienTexture;
        GraphicsDevice graphicsDevice;
        public Vector2 alienpos;
        const int alienVel = 100;
        ContentManager content;
        float dir = 1;
        Circle collider;
        Vector2 Size;
        Rectangle AliensHitbox;


        public Alien(SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.spriteBatch = spriteBatch; this.graphicsDevice = graphicsDevice;this.content = content;
            alienTexture = content.Load<Texture2D>("EndPoint_Black");
            alienpos = new Vector2(-graphicsDevice.Viewport.Width/2,graphicsDevice.Viewport.Height);
            Size = new Vector2(0.2f, alienTexture.Height * 0.2f / alienTexture.Width);
            collider = new Circle(alienpos, Size.Length() /2f);
            Point p = new Point(alienTexture.Width, alienTexture.Height);
            AliensHitbox = new Rectangle(alienpos.ToPoint(),p);



        }
        public void Draw()
        {
            spriteBatch.Draw(alienTexture, ConvertToDrawPos(alienpos), Color.White);
        }
        Vector2 ConvertToDrawPos(Vector2 pos)
        {
            return new Vector2(graphicsDevice.Viewport.Width / 2 + pos.X, graphicsDevice.Viewport.Height - pos.Y);
        }




        public void Movement(GameTime gameTime)
        {
            
            if (alienpos.X >= graphicsDevice.Viewport.Width/2)
            {
                dir = -dir;
                alienpos = alienpos + new Vector2(0, -40);

            }
            if (alienpos.X < -graphicsDevice.Viewport.Width / 2)
            {
                dir = -dir;
                alienpos = alienpos + new Vector2(0, -40);

            }
            
                alienpos.X += dir * (float)gameTime.ElapsedGameTime.TotalSeconds * 50;
            AliensHitbox.Location = alienpos.ToPoint();

        }

        public Rectangle gethitbox()
        {
            return this.AliensHitbox;
        }

        public string Name() { return "Alien"; }
        public void CollisionWith(ICollider other)
        {
            if (other.Name() == "Bullet")
            {
                System.Console.WriteLine("R.I.P.");
            }
        }
        public bool CollidesWith(ICollider other)
        {
            return collider.CollidesWith(other);
        }

        public ICollider GetCollider()
        {
            return collider;
        }
    }
}
