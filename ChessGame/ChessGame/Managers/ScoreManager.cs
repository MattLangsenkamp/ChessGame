using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using ChessGame.UtilitiesAndFactories;
using Microsoft.Xna.Framework;

namespace ChessGame.Managers
{
	class ScoreManager : IScoreManager
	{
		private int blackScore;
		private int whiteScore;
		private ISprite backRoundSprite;
		private ITextSprite blackScoreText;
		private ITextSprite whiteSocreText;
		private ITextSprite boardFlipText;

		public ScoreManager()
		{
			backRoundSprite = SpriteFactory.Instance.MakeScoreManagerBackRoundSprite();
		}
		public void Draw(SpriteBatch spriteBatch, IChessPiece[][] board)
		{
			Vector2 loc = new Vector2(board.Length * Utilities.PieceWidth, 0);
			//blackScoreText = new ITextSprite();
			//whiteSocreText = new ITextSprite();
			backRoundSprite.Draw(spriteBatch, loc);
		}

		public void PieceTaken(ChessPieceType.Color teamColorTaken, ChessPieceType.Type pieceTypeTaken)
		{
			switch (pieceTypeTaken)
			{
				case ChessPieceType.Type.Bishop:
					DecideScore(teamColorTaken, 3);
					break;
				case ChessPieceType.Type.King:
					DecideScore(teamColorTaken, 100);
					break;
				case ChessPieceType.Type.Knight:
					DecideScore(teamColorTaken, 3);
					break;
				case ChessPieceType.Type.Pawn:
					DecideScore(teamColorTaken, 1);
					break;
				case ChessPieceType.Type.Queen:
					DecideScore(teamColorTaken, 9);
					break;
				case ChessPieceType.Type.Rook:
					DecideScore(teamColorTaken, 5);
					break;
				case ChessPieceType.Type.Blank:
					DecideScore(teamColorTaken, 0);
					break;
				default:
					break;
			}
		}

		public void Update(Vector2 location)
		{
			
		}

		private void DecideScore(ChessPieceType.Color teamColorTaken, int amount)
		{
			if (teamColorTaken == ChessPieceType.Color.Black)
				whiteScore += amount;
			else
				blackScore += amount;
		}
	}
}
