using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RiverRaider.Class;
using RiverRaider.Class.Objects;
using RiverRaider.Class.ScreenScripts;
using System;
using System.Diagnostics;
using static RiverRaider.Class.MenuScreen;

namespace RiverRaid_Android {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static TextureManager textureManager;
        public static AudioManager audioManager;
        public static Color tlo = new Color(110, 156, 66);

        ControllerDetectScreen mControllerScreen;
        Screen mCurrentScreen;
        MenuScreen mMenuScreen;
        public static GameScreen mGameScreen;


        public static int WIDTH, HEIGHT;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();

            WIDTH = GraphicsDevice.Viewport.Width;
            HEIGHT = GraphicsDevice.Viewport.Height;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            LineBatch.Init(GraphicsDevice);

            textureManager = new TextureManager(this.Content);
            audioManager = new AudioManager(this.Content);

            mControllerScreen = new ControllerDetectScreen(this.Content, new EventHandler(ControllerDetectScreenEvent));
            mMenuScreen = new MenuScreen(this.Content, new EventHandler(MenuScreenEvent));
            mGameScreen = new GameScreen(this.Content, new EventHandler(GameScreenEvent));

            mCurrentScreen = mControllerScreen;
        }

        private void GameScreenEvent(object sender, EventArgs e) {

        }

        private void MenuScreenEvent(object sender, EventArgs e) {
            Optionn chosenOption = mMenuScreen.options.Find((option) => option.active);
            if (chosenOption.label.Equals("Play")) {
                mCurrentScreen = mGameScreen;
                mGameScreen.StartGame();

            } else if (chosenOption.label.Equals("Exit")) {
                Exit();
            }
        }

        public void ControllerDetectScreenEvent(object obj, EventArgs e) {
            mCurrentScreen = mMenuScreen;
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here
            mCurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(tlo);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
