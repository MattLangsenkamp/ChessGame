using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Commands
{
	class IsCheckMateCommand:CommandAbstractClass
	{
		public IsCheckMateCommand(IChessPiece[][] b)
		{
			board = b;
		}

		public override bool Execute(int x, int y)
		{
			int[] places = {x-1, y-1, x, y-1, x + 1, y-1,
				x-1, y, x+1, y,
				x-1, y+1, x, y+1, x + 1, y+1};

			if (!InCheck(x, y))
				return false;

			for(int i = 0; i<16; i =+ 2)
			{
				if(!InCheck(places[i],places[i+1]))
				{
					return false;
				}
			}

			return true;
		}

		bool InCheck(int x, int y)
		{
			if (HorizontalLeftCheck(x, y))
				return true;
			else if (HorizontalRightCheck(x, y))
				return true;
			else if (VerticalDownInCheck(x, y))
				return true;
			else if (VerticalUpInCheck(x, y))
				return true;
			else if (DiagonalLeftDownInCheck(x, y))
				return true;
			else if (DiagonalRightDownInCheck(x, y))
				return true;
			else if (DiagonalLeftUpInCheck(x, y))
				return true;
			else if (DiagonalRightUpInCheck(x, y))
				return true;
			else if (KnightMoveInCheck(x, y))
				return true;

			return false;
		}

		bool HorizontalRightCheck(int x, int y)
		{
			int xNew = x+1;
			while(IsOnBoard(xNew, y) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew++;
			}

			if (IsOnBoard(xNew, y) && IsEnemyInPosition(xNew, y, board[x][y].Color))
				if (board[xNew][y].Type == ChessPieceType.Type.Rook || board[xNew][y].Type == ChessPieceType.Type.Queen ||
					board[xNew][y].Type == ChessPieceType.Type.King)
					return true;
			return false;
		}
		bool HorizontalLeftCheck(int x, int y)
		{
			int xNew = x - 1;
			while (IsOnBoard(xNew, y) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew--;
			}

			if (IsOnBoard(xNew, y) && IsEnemyInPosition(xNew, y, board[x][y].Color))
				if (board[xNew][y].Type == ChessPieceType.Type.Rook || board[xNew][y].Type == ChessPieceType.Type.Queen ||
					board[xNew][y].Type == ChessPieceType.Type.King)
					return true;
			return false;
		}

			bool VerticalUpInCheck(int x, int y)
		{
			int yNew = y - 1;
			while (IsOnBoard(x, yNew) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
			}

			if (IsOnBoard(x, yNew) && IsEnemyInPosition(x, yNew, board[x][y].Color))
				if (board[x][yNew].Type == ChessPieceType.Type.Rook || board[x][yNew].Type == ChessPieceType.Type.Queen ||
					board[x][yNew].Type == ChessPieceType.Type.King)
					return true;
			return false;
		}

		bool VerticalDownInCheck(int x, int y)
		{
			int yNew = y + 1;
			while (IsOnBoard(x, yNew) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
			}

			if (IsOnBoard(x, yNew) && IsEnemyInPosition(x, yNew, board[x][y].Color))
				if (board[x][yNew].Type == ChessPieceType.Type.Rook || board[x][yNew].Type == ChessPieceType.Type.Queen ||
					board[x][yNew].Type == ChessPieceType.Type.King)
					return true;
			return false;
		}
			bool DiagonalRightDownInCheck(int x, int y)
		{
			int yNew = y + 1;
			int xNew = x + 1;
			while (IsOnBoard(xNew, yNew) && board[xNew][yNew].Color == ChessPieceType.Color.Blank )
			{
				yNew++;
				xNew++;
			}

			if (IsOnBoard(xNew, yNew) && IsEnemyInPosition(x, yNew, board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen ||
					board[xNew][yNew].Type == ChessPieceType.Type.King ||
					board[xNew][yNew].Type == ChessPieceType.Type.Pawn)
					return true;
			return false;
		}
		bool DiagonalLeftDownInCheck(int x, int y)
		{
			int yNew = y + 1;
			int xNew = x - 1;
			while (IsOnBoard(xNew, yNew) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
				xNew--;
			}

			if (IsOnBoard(xNew, yNew) && IsEnemyInPosition(x, yNew, board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen ||
					board[xNew][yNew].Type == ChessPieceType.Type.King ||
					board[xNew][yNew].Type == ChessPieceType.Type.Pawn)
					return true;
			return false;
		}

		bool DiagonalRightUpInCheck(int x, int y)
		{
			int yNew = y - 1;
			int xNew = x + 1;
			while (IsOnBoard(xNew, yNew) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
				xNew++;
			}

			if (IsOnBoard(xNew, yNew) && IsEnemyInPosition(x, yNew, board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen ||
					board[xNew][yNew].Type == ChessPieceType.Type.King ||
					board[xNew][yNew].Type == ChessPieceType.Type.Pawn)
					return true;
			return false;
		}
		bool DiagonalLeftUpInCheck(int x, int y)
		{
			int yNew = y - 1;
			int xNew = x - 1;
			while (IsOnBoard(xNew, yNew) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
				xNew--;
			}

			if (IsOnBoard(xNew, yNew) && IsEnemyInPosition(x, yNew, board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen ||
					board[xNew][yNew].Type == ChessPieceType.Type.King ||
					board[xNew][yNew].Type == ChessPieceType.Type.Pawn)
					return true;
			return false;
		}

		bool KnightMoveInCheck(int x, int y)
		{
			int[] xNews = {x-1, x+1, x+2, x+2, x+1, x-1, x-2, x-2};
			int[] yNews = {y-2, y-2, y-1, y+1, y+2, y+2, y+1, y-1};
			int counter = 0;
			while(IsOnBoard(xNews[counter],yNews[counter]))
			{
				if (board[xNews[counter]][yNews[counter]].Type == ChessPieceType.Type.Knight)
					return true;
				counter++;
			}
			return false;
		}
	}
}
