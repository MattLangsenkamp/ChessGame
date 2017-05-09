using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ChessGame.Managers
{
	class CheckMateManager:ICheckMateManager
	{
		private ChessPieceType.Color turnColor;
		public CheckMateManager()
		{
			turnColor = ChessPieceType.Color.White;
		}
		public void ChangeTurn()
		{
			if (turnColor == ChessPieceType.Color.White)
				turnColor = ChessPieceType.Color.Black;
			else
				turnColor = ChessPieceType.Color.White;
		}

		public Vector2 FindKing(IChessPiece[][] board, ChessPieceType.Color color)
		{
			Vector2 retVal = new Vector2(0);
			for (int y = 0;  y<board.Length; y++)
			{
				for(int x = 0; x<board.Length; x++)
				{
					if (board[x][y].Type == ChessPieceType.Type.King && board[x][y].Color == color)
					{
						retVal = new Vector2(x, y);
						return retVal;
					}
				}
			}
			return retVal;
		}

		public bool IsInCheck(IChessPiece[][] board, Vector2 location)
		{
			if (HorizontalLeftCheck(board, location))
				return true;
			else if (HorizontalRightCheck(board, location))
				return true;
			else if (VerticalDownInCheck(board, location))
				return true;
			else if (VerticalUpInCheck(board, location))
				return true;
			else if (DiagonalLeftDownInCheck(board, location))
				return true;
			else if (DiagonalRightDownInCheck(board, location))
				return true;
			else if (DiagonalLeftUpInCheck(board, location))
				return true;
			else if (DiagonalRightUpInCheck(board, location))
				return true;
			else if (KnightMoveInCheck(board, location))
				return true;

			return false;
		}

		public bool IsInCheckMate(IChessPiece[][] board, Vector2 location)
		{
			if (!IsInCheck(board, location))
				return false;

			int x = (int)location.X;
			int y = (int)location.Y;

			int[] places = {x-1, y-1, x, y-1, x + 1, y-1,
				x-1, y, x+1, y,
				x-1, y+1, x, y+1, x + 1, y+1};

			for (int i = 0; i < 16; i = +2)
			{
				if (!IsInCheck(board, new Vector2(places[i], places[i + 1])))
				{
					return false;
				}
			}

			return true;
		}

		private bool HorizontalRightCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int xNew = x + 1;

			if (IsOnBoard(board, new Vector2(xNew, y)) && IsEnemyInPosition(board, new Vector2(xNew, y), board[x][y].Color))
				if (board[xNew][y].Type == ChessPieceType.Type.King)
					return true;
			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew++;
			}

			if (IsOnBoard(board, new Vector2(xNew, y)) && IsEnemyInPosition(board, new Vector2(xNew, y), board[x][y].Color))
				if (board[xNew][y].Type == ChessPieceType.Type.Rook || board[xNew][y].Type == ChessPieceType.Type.Queen)
					return true;
			return false;
		}
		private bool HorizontalLeftCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int xNew = x - 1;

			if (IsOnBoard(board, new Vector2(xNew, y)) && IsEnemyInPosition(board, new Vector2(xNew, y), board[x][y].Color))
				if (board[xNew][y].Type == ChessPieceType.Type.King)
					return true;
			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew--;
			}

			if (IsOnBoard(board, new Vector2(xNew, y)) && IsEnemyInPosition(board, new Vector2(xNew, y), board[x][y].Color))
				if (board[xNew][y].Type == ChessPieceType.Type.Rook || board[xNew][y].Type == ChessPieceType.Type.Queen)
					return true;
			return false;
		}

		private bool VerticalUpInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y - 1;

			if (IsOnBoard(board, new Vector2(x, yNew)) && IsEnemyInPosition(board, new Vector2(x, yNew), board[x][y].Color))
				if (board[x][yNew].Type == ChessPieceType.Type.King)
					return true;

			while (IsOnBoard(board, new Vector2(x, yNew)) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
			}

			if (IsOnBoard(board, new Vector2(x, yNew)) && IsEnemyInPosition(board, new Vector2(x, yNew), board[x][y].Color))
				if (board[x][yNew].Type == ChessPieceType.Type.Rook || board[x][yNew].Type == ChessPieceType.Type.Queen)
					return true;
			return false;
		}

		private bool VerticalDownInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y + 1;

			if (IsOnBoard(board, new Vector2(x, yNew)) && IsEnemyInPosition(board, new Vector2(x, yNew), board[x][y].Color))
				if (board[x][yNew].Type == ChessPieceType.Type.King)
					return true;
			while (IsOnBoard(board, new Vector2(x, yNew)) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
			}

			if (IsOnBoard(board, new Vector2(x, yNew)) && IsEnemyInPosition(board, new Vector2(x, yNew), board[x][y].Color))
				if (board[x][yNew].Type == ChessPieceType.Type.Rook || board[x][yNew].Type == ChessPieceType.Type.Queen)
					return true;
			return false;
		}
		private bool DiagonalRightDownInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y + 1;
			int xNew = x + 1;
			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Pawn || board[xNew][yNew].Type == ChessPieceType.Type.King)
					return true;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
				xNew++;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
					return true;
				
			return false;
		}
		private bool DiagonalLeftDownInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y + 1;
			int xNew = x - 1;
			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.King || board[xNew][yNew].Type == ChessPieceType.Type.Pawn)
					return true;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
				xNew--;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
					return true;
			return false;
		}

		private bool DiagonalRightUpInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y - 1;
			int xNew = x + 1;

			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.King || board[xNew][yNew].Type == ChessPieceType.Type.Pawn)
					return true;

			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
				xNew++;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
					return true;
			return false;
		}
		private bool DiagonalLeftUpInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y - 1;
			int xNew = x - 1;
			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.King ||
					board[xNew][yNew].Type == ChessPieceType.Type.Pawn)
					return true;

			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
				xNew--;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)) && IsEnemyInPosition(board, new Vector2(xNew, yNew), board[x][y].Color))
				if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
					return true;
			return false;
		}

		private bool KnightMoveInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int[] xNews = { x - 1, x + 1, x + 2, x + 2, x + 1, x - 1, x - 2, x - 2 };
			int[] yNews = { y - 2, y - 2, y - 1, y + 1, y + 2, y + 2, y + 1, y - 1 };
			int counter = 0;
			for(int i = 0; i<board.Length;i++)
			{
				if (IsOnBoard(board, new Vector2(xNews[counter], yNews[counter])) &&
					board[xNews[counter]][yNews[counter]].Type == ChessPieceType.Type.Knight)
						return true;
			}
			
			return false;
		}
		private bool IsOnBoard(IChessPiece[][] board, Vector2 location)
		{
			if (location.X >= board.Length || location.X < 0)
				return false;
			if (location.Y >= board.Length || location.Y < 0)
				return false;
			return true;
		}

		private bool IsEnemyInPosition(IChessPiece[][] board, Vector2 l, ChessPieceType.Color teamColor)
		{
			if (board[(int)l.X][(int)l.Y].Color == teamColor || board[(int)l.X][(int)l.Y].Color == ChessPieceType.Color.Blank)
				return false;
			return true;
		}
	}
}
