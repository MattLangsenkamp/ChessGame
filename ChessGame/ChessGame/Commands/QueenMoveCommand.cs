using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ChessGame.PieceObjects;

namespace ChessGame.Commands
{
	class QueenMoveCommand : CommandAbstractClass
	{
		public override bool Execute(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			if (!IsOnBoard(board, newLocation))
				return false;
			if (IsTeamMateInPosition(board, newLocation, board[(int)curLocation.X][(int)curLocation.Y].Color))
				return false;


			return CheckInPositionAxis(board,newLocation,curLocation) || CheckInPositionDiagonal(board, newLocation, curLocation);
		}
		private bool CheckInPositionAxis(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;

			int xNew = x + 1;
			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew++;
			}
			if (newLocation.X == xNew && newLocation.Y == y)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}

			xNew = x - 1;
			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew--;
			}
			if (newLocation.X == xNew && newLocation.Y == y)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}

			int yNew = y + 1;
			while (IsOnBoard(board, new Vector2(x, yNew)) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
			}
			if (newLocation.X == x && newLocation.Y == yNew)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}

			yNew = x - 1;
			while (IsOnBoard(board, new Vector2(x, yNew)) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
			}
			if (newLocation.X == x && newLocation.Y == yNew)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}
			return false;
		}
		private bool CheckInPositionDiagonal(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;

			int xNew = x + 1;
			int yNew = y + 1;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				xNew++;
				yNew++;
			}
			if (newLocation.X == xNew && newLocation.Y == yNew)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}

			xNew = x - 1;
			yNew = y + 1;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				xNew--;
				yNew++;
			}
			if (newLocation.X == xNew && newLocation.Y == yNew)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}

			xNew = x + 1;
			yNew = y - 1;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				xNew++;
				yNew--;
			}
			if (newLocation.X == xNew && newLocation.Y == yNew)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}

			xNew = x - 1;
			yNew = y - 1;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
				xNew++;
			}
			if (newLocation.X == xNew && newLocation.Y == yNew)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}
			return false;
		}
	}
}
