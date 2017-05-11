using ChessGame.Commands;
using ChessGame.Interfaces;
using ChessGame.UtilitiesAndFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ChessGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		BoardManager boardManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = Utilities.ScreenDimensionX;
			graphics.PreferredBackBufferHeight = Utilities.ScreenDimensionY;
			graphics.ApplyChanges();
			Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
			// TODO: Add your initialization logic here
			this.IsMouseVisible = true;
			SpriteFactory.Instance.LoadContent(Content);
			boardManager = new BoardManager();
            base.Initialize();
		}

        protected override void LoadContent()
        {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			boardManager.AddCommand(new BishopMoveCommand(), ChessPieceType.Type.Bishop);
			boardManager.AddCommand(new KingMoveCommand(), ChessPieceType.Type.King);
			boardManager.AddCommand(new KnightMoveCommand(), ChessPieceType.Type.Knight);
			boardManager.AddCommand(new PawnMoveCommand(), ChessPieceType.Type.Pawn);
			boardManager.AddCommand(new QueenMoveCommand(), ChessPieceType.Type.Queen);
			boardManager.AddCommand(new RookMoveCommand(), ChessPieceType.Type.Rook);
		}

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
			boardManager.Update();
            base.Update(gameTime);
        }

		public Vector3 GetScreenScale
		{
			get
			{
				var scaleX = GraphicsDevice.Viewport.Width / 900f;
				var scaleY = GraphicsDevice.Viewport.Height / 900f;
				return new Vector3(scaleX, scaleY, 1.0f);
			}
		}
		public Matrix GetTransform
		{
			get
			{
				var translationMatrix = Matrix.CreateTranslation(new Vector3(0, 0, 0));
				var rotationMatrix = Matrix.CreateRotationZ(0);
				var scaleMatrix = Matrix.CreateScale(new Vector3(.270264f, .33783f, 0));
				var originMatrix = Matrix.CreateTranslation(new Vector3(0, 0, 0));

				return translationMatrix * rotationMatrix * scaleMatrix * originMatrix;
			}
		}
		protected override void Draw(GameTime gameTime)
        {
			var screenScale = GetScreenScale;
			var viewMatrix = GetTransform;
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
									   null, null, null, null, viewMatrix * Matrix.CreateScale(screenScale));

			GraphicsDevice.Clear(Color.CornflowerBlue);
			boardManager.Draw(spriteBatch);
            base.Draw(gameTime);
			spriteBatch.End();
        }
    }
}
