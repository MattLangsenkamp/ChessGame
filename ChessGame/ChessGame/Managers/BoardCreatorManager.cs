using ChessGame.Interfaces;
using ChessGame.PieceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Managers
{
	public class BoardCreatorManager : IBoardCreatorManager
	{
		public BoardCreatorManager()
		{

		}
		public IChessPiece[][] BuildBoard()
		{
			IChessPiece[][] retBoard = new IChessPiece[8][];
			for (int i = 0; i < 8; i++)
			{
				retBoard[i] = new IChessPiece[8];
			}
			return retBoard;
		}
		public IChessPiece[][] CopyBoard(IChessPiece[][] b)
		{
			IChessPiece[][] retBoard = BuildBoard();
			for (int y = 0; y < b.Length; y++)
			{
				for (int x = 0; x < b.Length; x++)
				{
					retBoard[x][y] = b[x][y];
				}
			}
			return retBoard;
		}

		public void InitializeBoard(IChessPiece[][] board)
		{
			board[0][0] = new RookPieceBlack();
			board[1][0] = new KnightPieceBlack();
			board[2][0] = new BishopPieceBlack();
			board[3][0] = new QueenPieceBlack();
			board[4][0] = new KingPieceBlack();
			board[5][0] = new BishopPieceBlack();
			board[6][0] = new KnightPieceBlack();
			board[7][0] = new RookPieceBlack();
			board[0][7] = new RookPieceWhite();
			board[1][7] = new KnightPieceWhite();
			board[2][7] = new BishopPieceWhite();
			board[3][7] = new QueenPieceWhite();
			board[4][7] = new KingPieceWhite();
			board[5][7] = new BishopPieceWhite();
			board[6][7] = new KnightPieceWhite();
			board[7][7] = new RookPieceWhite();
			for (int i = 0; i < 8; i++)
			{
				board[i][1] = new PawnPieceBlack();
				board[i][6] = new PawnPieceWhite();
				board[i][2] = new BlankPiece();
				board[i][3] = new BlankPiece();
				board[i][4] = new BlankPiece();
				board[i][5] = new BlankPiece();
			}
		}
	}
}
