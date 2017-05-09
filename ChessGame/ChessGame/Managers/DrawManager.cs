using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Managers
{
	class DrawManager: IDrawManager
	{
		private int highlightX;
		private int highlightY;
		private ChessPieceType.Color turnColor;
		public DrawManager()
		{
			turnColor = ChessPieceType.Color.White;
		}
		public void Draw(SpriteBatch spriteBatch, IChessPiece[][] board)
		{
			DrawBoard(spriteBatch);
			if (turnColor == ChessPieceType.Color.White)
				DrawPiecesWhite(spriteBatch, board);
			else
				DrawPiecesBlack(spriteBatch, board);
		}
		public void ChangeTurn()
		{
			if (turnColor == ChessPieceType.Color.White)
				turnColor = ChessPieceType.Color.Black;
			else
				turnColor = ChessPieceType.Color.White;
		}
		public void HighLightPiece(Vector2 vect)
		{
			highlightX = (int)vect.X;
			highlightY = (int)vect.Y;
		}

		private void DrawPiecesWhite(SpriteBatch spriteBatch, IChessPiece[][] board)
		{
			for(int i = 0; i< board.Length;i++)
			{
				for(int j = 0; j < board.Length; j++)
				{
					board[j][i].Draw(spriteBatch, new Vector2(j*SpriteFactory.Instance.PieceWidth, i * SpriteFactory.Instance.PieceHeight));
				}
			}
		}
		private void DrawPiecesBlack(SpriteBatch spriteBatch, IChessPiece[][] board)
		{
			int offSet = board.Length - 1;
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board.Length; j++)
				{
					board[offSet - j][offSet - i].Draw(spriteBatch, new Vector2(j * SpriteFactory.Instance.PieceWidth, i * SpriteFactory.Instance.PieceHeight));
				}
			}
		}
		private void DrawBoard(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					ISprite curSprite = DecideBoardColor(j, i);
					
					Vector2 loc = new Vector2(j * SpriteFactory.Instance.PieceWidth, i * SpriteFactory.Instance.PieceHeight);
					curSprite.Draw(spriteBatch,loc);
				}
			}
		}

		private ISprite DecideBoardColor(int j, int i)
		{
			ISprite curSprite;
			if (j % 2 == 0)
				if (i % 2 == 0)
					curSprite = DecideColor(j, i, ChessPieceType.BoardColor.Tan);
				else
					curSprite = DecideColor(j, i, ChessPieceType.BoardColor.Maroon);
			else
				if (i % 2 != 0)
					curSprite = DecideColor(j, i, ChessPieceType.BoardColor.Tan);
				else
					curSprite = DecideColor(j, i, ChessPieceType.BoardColor.Maroon);

			return curSprite;
		}

		private ISprite DecideColor(int j, int i, ChessPieceType.BoardColor Color)
		{
			ISprite curSprite;
			if(Color == ChessPieceType.BoardColor.Maroon)
			{
				if (j == highlightX & i == highlightY)
					curSprite = SpriteFactory.Instance.MakeLightMaroonBoardSprite(); ///
				else
					curSprite = SpriteFactory.Instance.MakeMaroonBoardSprite();
			}
			else
			{
				if (j == highlightX & i == highlightY)
					curSprite = SpriteFactory.Instance.MakeLightTanBoardSprite(); ///
				else
					curSprite = SpriteFactory.Instance.MakeTanBoardSprite();
			}
			return curSprite;
		}
	}
}
