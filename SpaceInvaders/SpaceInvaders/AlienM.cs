using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SpaceInvaders
{
    class AlienM
    {
        SpriteBatch spriteBatch;
        Texture2D alienTexture;
        GraphicsDevice graphicsDevice;
        ContentManager content;
        
        

        public List<Alien> alien;
        public AlienM(SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.spriteBatch = spriteBatch; this.graphicsDevice = graphicsDevice; this.content = content;
            alienTexture = content.Load<Texture2D>("EndPoint_Black");

            alien = new List<Alien>();

            alienspwan();

        }

        public void alienspwan()
        {

            for (int x = 0; x < 10; x++)
            {
                Alien a = new Alien(spriteBatch, content, graphicsDevice);
                a.alienpos.X += x * 80;
                alien.Add(a);
            }



        }
        public void Update(GameTime gameTime)
        {
            
            foreach (Alien a in alien)
            {
                
                a.Movement(gameTime);
                
            }

        }
        public void Draw()
        {
            foreach (Alien a in alien)
            {
                a.Draw();
            }
        }

        
    }
}
