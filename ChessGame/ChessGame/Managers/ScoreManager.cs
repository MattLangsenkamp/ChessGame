using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using ChessGame.UtilitiesAndFactories;
using Microsoft.Xna.Framework;
using ChessGame.Sprites;
using ChessGame.Buttons;

namespace ChessGame.Managers
{
	class ScoreManager : IScoreManager
	{
		private int blackScore;
		private int whiteScore;
		private int[][] buttonList;

		private ChessPieceType.Color turnColor;

		private ISprite backRoundSprite;
		private ITextSprite turnText;
		private ITextSprite blackScoreText;
		private ITextSprite whiteScoreText;
		private ITextSprite boardFlipText;
		private ArrowButton leftArrow;
		private ArrowButton rightArrow;


		public ScoreManager()
		{
			turnColor = ChessPieceType.Color.White;
			backRoundSprite = SpriteFactory.Instance.MakeScoreManagerBackRoundSprite();
			turnText = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
			turnText.Text = "White's turn";
			blackScoreText = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
			blackScoreText.Text = "Black's Score: 0";
			whiteScoreText = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
			whiteScoreText.Text = "Whites's Score: 0";
			boardFlipText = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
			boardFlipText.Text = "Flip Board";
			leftArrow = new ArrowButton(ChessPieceType.Direction.Left, new Vector2(8 * Utilities.PieceWidth, 4 * Utilities.PieceHeight));
			rightArrow = new ArrowButton(ChessPieceType.Direction.Right, new Vector2(8 * Utilities.PieceWidth + Utilities.PieceWidth, 4 * Utilities.PieceHeight));

			buttonList = new int[2][];
			for (int i = 0; i < 2; i++)
				buttonList[i] = new int[8];

			for (int i = 0; i < 2; i++)
				for (int j = 0; j < 8; j++)
					if (i == 0)
						buttonList[i][j] = 2 * j;
					else
						buttonList[i][j] = 2 * j + 1;

		}
		public void Draw(SpriteBatch spriteBatch, IChessPiece[][] board)
		{
			Vector2 loc = new Vector2(board.Length * Utilities.PieceWidth, 0);
			backRoundSprite.Draw(spriteBatch, loc);
			turnText.Draw(spriteBatch, new Vector2(8 * Utilities.PieceWidth, 0));
			whiteScoreText.Draw(spriteBatch, new Vector2(8 * Utilities.PieceWidth, 1 * Utilities.PieceHeight));
			blackScoreText.Draw(spriteBatch, new Vector2(8 * Utilities.PieceWidth, 2 * Utilities.PieceHeight));
			boardFlipText.Draw(spriteBatch, new Vector2(8 * Utilities.PieceWidth, 3 * Utilities.PieceHeight));
			leftArrow.Draw(spriteBatch);
			rightArrow.Draw(spriteBatch);		
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

		public ChessPieceType.ClickCommand Update(Vector2 location)
		{
			if (turnColor == ChessPieceType.Color.White)
				turnText.Text = "White's turn";
			else
				turnText.Text = "Black's turn";
			blackScoreText.Text = "Black's Score: "+blackScore;
			whiteScoreText.Text = "Whites's Score: "+whiteScore;
			return ButtonPressed(location);
		}

		private void DecideScore(ChessPieceType.Color teamColorTaken, int amount)
		{
			if (teamColorTaken == ChessPieceType.Color.Black)
				whiteScore += amount;
			else
				blackScore += amount;
		}

		private ChessPieceType.ClickCommand ButtonPressed(Vector2 loc)
		{
			int button = buttonList[(int)loc.X - 8][(int)loc.Y];
			ChessPieceType.ClickCommand retVal = ChessPieceType.ClickCommand.NoClick;
			switch (button)
			{
				case 0:
					break;
				case 1:
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 5:
					break;
				case 6:
					retVal = ChessPieceType.ClickCommand.FlipBoard;
					break;
				case 7:
					retVal = ChessPieceType.ClickCommand.FlipBoard;				
					break;
				case 8:
					retVal = ChessPieceType.ClickCommand.PreviousBoard;				
					break;
				case 9:
					retVal = ChessPieceType.ClickCommand.NextBoard;
					break;
				case 10:
					break;
				case 11:
					break;
				case 12:
					break;
				case 13:
					break;
				case 14:
					break;
				case 15:
					break;
				case 16:
					break;
				default:
					break;
			}
			Console.WriteLine(retVal);
			return retVal;
		}


		public void ChangeTurn()
		{
			if (turnColor == ChessPieceType.Color.White)
				turnColor = ChessPieceType.Color.Black;
			else
				turnColor = ChessPieceType.Color.White;
		}
	}
}
