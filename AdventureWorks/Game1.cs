using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace AdventureWorks
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameState gameState;

        SpriteFont font;
        Map gameMap;
        TextBox gameTextBox;
        

        String startingText;

        KeyboardState kbState;
        KeyboardState lastKBState;

        //keylockswitch
        bool keyLock;
        bool keyLatch;
        int keyLockTimer;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GameConstants.WindowWidth;
            graphics.PreferredBackBufferHeight = GameConstants.WindowHight;
            gameState = new GameState();
            //keylockswitch
            keyLock = true;
            keyLatch = false;
            keyLockTimer = 0;
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // load sprite font
            font = Content.Load<SpriteFont>("Arial20");
            
            gameMap = new Map(Content);
            gameTextBox = new TextBox(Content,gameState);
            startingText = "Never does a star grace this land with a poets light of twinkling mysteries, nor does the sun send to here its rays of warmth and life. This is the Underdark, the secret world beneath the bustling surface of the Forgotten Realms, whose sky is a ceiling of heartless stone and whose walls show the gray blandness of death in the torchlight of the foolish surface-dwellers that stumble here. This is not their world, not the world of light. Most who come here uninvited do not return.";
            

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.F2))
            {
                gameState.SetState(GameState.State.intro);
            }

            if (kbState.IsKeyDown(Keys.F3))
            {
                gameState.SetState(GameState.State.map);
            }

            if (kbState.IsKeyDown(Keys.F1) && lastKBState.IsKeyUp(Keys.F1))
            {
                gameTextBox.AddText(startingText);
            }
            if (kbState.IsKeyDown(Keys.Enter) && lastKBState.IsKeyUp(Keys.Enter))
            {
                gameTextBox.Dump();
            }

            if(gameState.GetState() == GameState.State.map)
            {
                if (kbState.IsKeyDown(Keys.W) && (lastKBState.IsKeyUp(Keys.W) || keyLock))
                {
                    gameMap.MoveCharacter(MainCharacter.Direction.Up);
                    keyLock = false;
                }
                if (kbState.IsKeyDown(Keys.S) && (lastKBState.IsKeyUp(Keys.S) || keyLock))
                {
                    gameMap.MoveCharacter(MainCharacter.Direction.Down);
                    keyLock = false;
                }
                if (kbState.IsKeyDown(Keys.A) && (lastKBState.IsKeyUp(Keys.A) || keyLock))
                {
                    gameMap.MoveCharacter(MainCharacter.Direction.Left);
                    keyLock = false;
                }
                if (kbState.IsKeyDown(Keys.D) && (lastKBState.IsKeyUp(Keys.D) || keyLock))
                {
                    gameMap.MoveCharacter(MainCharacter.Direction.Right);
                    keyLock = false;
                }
                if (kbState.IsKeyDown(Keys.Up) && (lastKBState.IsKeyUp(Keys.Up) || keyLock))
                {
                    gameMap.Update(0, -1);
                    keyLock = false;
                }
                if (kbState.IsKeyDown(Keys.Down) && (lastKBState.IsKeyUp(Keys.Down) || keyLock))
                {
                    gameMap.Update(0, 1);
                    keyLock = false;
                }
                if (kbState.IsKeyDown(Keys.Left) && (lastKBState.IsKeyUp(Keys.Left) || keyLock))
                {
                    gameMap.Update(-1, 0);
                    keyLock = false;
                }
                if (kbState.IsKeyDown(Keys.Right) && (lastKBState.IsKeyUp(Keys.Right) || keyLock))
                {
                    gameMap.Update(1, 0);
                    keyLock = false;
                }
            }

            if(!keyLock)
            {
                if (!keyLatch && keyLockTimer > 1000)
                {
                    keyLock = true;
                    keyLockTimer = 0;
                    keyLatch = true;
                }
                if(keyLatch && keyLockTimer > 150)
                {
                    keyLock = true;
                    keyLockTimer = 0;
                }
            }

            if(kbState.IsKeyUp(Keys.W) && kbState.IsKeyUp(Keys.A) && kbState.IsKeyUp(Keys.S) && kbState.IsKeyUp(Keys.D))
            {
                keyLatch = false;
                keyLock = false;
            }

            keyLockTimer += gameTime.ElapsedGameTime.Milliseconds;
            gameTextBox.Update(gameTime, gameState);

            lastKBState = kbState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();


            if(gameState.GetState() == GameState.State.map)
            {
                gameMap.Draw(spriteBatch);
                
            }

            gameTextBox.Draw(spriteBatch);
            


            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
