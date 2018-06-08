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

namespace ExButtonXNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        enum GameState
        {
            MainMenu,
            HowToPLay,
            Playing,
            About,
            Back,
            Exit,
        }
        GameState CurrentGameState = GameState.MainMenu;

        int ws , hs;
        cButton btnPlay, btnHowToPlay, btnAbout, btnBack, btnExit;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            ws = this.Window.ClientBounds.Width;
            hs = this.Window.ClientBounds.Height;

            btnPlay = new cButton(this, Content.Load<Texture2D>("play"));
            btnHowToPlay = new cButton(this, Content.Load<Texture2D>("HowToPlay"));
            btnBack = new cButton(this, Content.Load<Texture2D>("Back"));
            btnAbout = new cButton(this, Content.Load<Texture2D>("About"));
            btnExit = new cButton(this, Content.Load<Texture2D>("Exit"));

            btnPlay.setPosition(new Vector2(ws / 2 - 75, hs / 2 - 200));
            btnHowToPlay.setPosition(new Vector2(ws / 2 - 75, hs / 2 - 100));
            btnAbout.setPosition(new Vector2(ws / 2 - 75, hs / 2));
            btnExit.setPosition(new Vector2(ws / 2 - 75, hs / 2 + 100));
            btnBack.setPosition(new Vector2(ws - 150, hs - 50));
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

            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.Isclicked) CurrentGameState = GameState.Playing;
                    if (btnHowToPlay.Isclicked) CurrentGameState = GameState.HowToPLay;
                    if (btnAbout.Isclicked) CurrentGameState = GameState.About;
                    if (btnExit.Isclicked) CurrentGameState = GameState.Exit;
                    btnPlay.Update(mouse);
                    btnHowToPlay.Update(mouse);
                    btnAbout.Update(mouse);
                    btnExit.Update(mouse);
                    break;
                case GameState.Playing:
                    if (btnBack.Isclicked) CurrentGameState = GameState.MainMenu;
                    btnBack.Update(mouse);
                    break;
                case GameState.About:
                    if (btnBack.Isclicked) CurrentGameState = GameState.MainMenu;
                    btnBack.Update(mouse);
                    break;
                case GameState.HowToPLay:
                    if (btnBack.Isclicked) CurrentGameState = GameState.MainMenu;
                    btnBack.Update(mouse);
                    break;
                case GameState.Back:
                    CurrentGameState = GameState.MainMenu;
                    break;
                case GameState.Exit:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    btnPlay.Draw(spriteBatch);
                    btnHowToPlay.Draw(spriteBatch);
                    btnAbout.Draw(spriteBatch);
                    btnExit.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    btnBack.Draw(spriteBatch);
                    break;
                case GameState.HowToPLay:
                    btnBack.Draw(spriteBatch);
                    break;
                case GameState.About:
                    btnBack.Draw(spriteBatch);
                    break;
                case GameState.Back:
                    CurrentGameState = GameState.MainMenu;
                    break;
                case GameState.Exit:
                    this.Exit();
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
