using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Ship ship;
        ColisionM colisionM;
        KeyboardManager Km;
        AlienM alienM;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Km = new KeyboardManager();
            
           
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ship = new Ship(Km,_spriteBatch,Content,GraphicsDevice);
            alienM = new AlienM(_spriteBatch, Content, GraphicsDevice);
            colisionM = new ColisionM(alienM.alien,ship.bullets);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Km.Update();

            // TODO: Add your update logic here
            ship.Movement(gameTime);
            alienM.Update(gameTime);
            ship.shoot(gameTime);
            colisionM.colision();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(); 
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            ship.Draw();
            alienM.Draw();
            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
