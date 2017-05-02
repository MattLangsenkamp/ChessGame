using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Interfaces;
using ChessGame.Sprites;

namespace ChessGame
{
	public class SpriteFactory
	{
		private static SpriteFactory instance = new SpriteFactory();
		public static SpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}
		public int PieceWidth { get; } = 333;
		public int PieceHeight { get; } = 333;
		private Texture2D textureSheet;
		private Texture2D maroonBoardSheet;
		private Texture2D tanBoardSheet;

		public void LoadContent(ContentManager content)
		{
			textureSheet = content.Load<Texture2D>("chessSprites");
			maroonBoardSheet = content.Load<Texture2D>("MaroonBoardPiece");
			tanBoardSheet = content.Load<Texture2D>("TanBoardPiece");
		}

		private SpriteFactory()
		{

		}

		public ISprite MakeBishopSpriteBlack()
		{
			return new BishopSpriteBlack(textureSheet);
		}
		public ISprite MakeBishopSpriteWhite()
		{
			return new BishopSpriteWhite(textureSheet);
		}
		public ISprite MakeKnightSpriteBlack()
		{
			return new KnightSpriteBlack(textureSheet);
		}
		public ISprite MakeKnightSpriteWhite()
		{
			return new KnightSpriteWhite(textureSheet);
		}
		public ISprite MakeKingSpriteBlack()
		{
			return new KingSpriteBlack(textureSheet);
		}
		public ISprite MakeKingSpriteWhite()
		{
			return new KingSpriteWhite(textureSheet);
		}
		public ISprite MakePawnSpriteBlack()
		{
			return new PawnSpriteBlack(textureSheet);
		}
		public ISprite MakePawnSpriteWhite()
		{
			return new PawnSpriteWhite(textureSheet);
		}
		public ISprite MakeQueenSpriteBlack()
		{
			return new QueenSpriteBlack(textureSheet);
		}
		public ISprite MakeQueenSpriteWhite()
		{
			return new QueenSpriteWhite(textureSheet);
		}
		public ISprite MakeRookSpriteBlack()
		{
			return new RookSpriteBlack(textureSheet);
		}
		public ISprite MakeRookSpriteWhite()
		{
			return new RookSpriteWhite(textureSheet);
		}
		public ISprite MakeMaroonBoardSprite()
		{
			return new BoardSprite(maroonBoardSheet);
		}
		public ISprite MakeTanBoardSprite()
		{
			return new BoardSprite(tanBoardSheet);
		}
	}
}
