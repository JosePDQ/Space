using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace SpaceInvaders
{
 
    class Bullet
    {
        SpriteBatch spriteBatch;
        KeyboardManager Km;
        Texture2D bulletTexture;
        GraphicsDevice graphicsDevice;
        Vector2 bulletPos;
        const int bulletVel = 100;
        Circle collider;
        Ship Ship;
        Vector2 Size;
        Rectangle BulletHitbox;
        
        
        

        bool isInstantiated = false;

        public Bullet(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice, Ship ship)
        {
            this.Km = km;
            
            this.spriteBatch = spriteBatch; this.graphicsDevice = graphicsDevice;
            bulletTexture = content.Load<Texture2D>("projectileRed");
            bulletPos = ship.givePos();
            isInstantiated = true;
            Size = new Vector2(0.2f, bulletTexture.Height * 0.2f / bulletTexture.Width);
            collider = new Circle(bulletPos, Size.Length() / 2f);
            Point p = new Point(bulletTexture.Width, bulletTexture.Height);
            BulletHitbox = new Rectangle(bulletPos.ToPoint(), p);



        }
        public void Update(GameTime gameTime)
        {
            if (!isInstantiated) return;
            bulletPos.Y += 1 * (float)gameTime.ElapsedGameTime.TotalSeconds * bulletVel;
            BulletHitbox.Location = bulletPos.ToPoint();
        }

        public void Draw()
        {
            if (!isInstantiated) return;

            spriteBatch.Draw(bulletTexture, ConvertToDrawPos(bulletPos), Color.White);

        }

        public bool colisao(Rectangle hitbox) 
        {
            if (BulletHitbox.Intersects(hitbox))
                return true;
            else return false;
        }


        Vector2 ConvertToDrawPos(Vector2 pos)
        {
            return new Vector2(graphicsDevice.Viewport.Width / 2 + pos.X, graphicsDevice.Viewport.Height - pos.Y);
        }



        
    }
}
