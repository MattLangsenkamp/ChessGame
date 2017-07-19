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
			if (newLocation.X != curLocation.X && newLocation.Y != curLocation.Y)
				return false;

			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;
			int xMoveInt = 0;
			int yMoveInt = 0;

			if (newLocation.X > curLocation.X)
			{
				xMoveInt = 1; yMoveInt = 0;
			}
			else if (newLocation.X < curLocation.X)
			{
				xMoveInt = -1; yMoveInt = 0;
			}
			else if (newLocation.Y > curLocation.Y)
			{
				xMoveInt = 0; yMoveInt = 1;
			}
			else if (newLocation.Y < curLocation.Y)
			{
				xMoveInt = 0; yMoveInt = -1;
			}
			int xNew = x + xMoveInt;
			int yNew = y + yMoveInt;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank
				&& !(newLocation.X == xNew && newLocation.Y == yNew))
			{
				xNew += xMoveInt;
				yNew += yMoveInt;
			}
			if (newLocation.X == xNew && newLocation.Y == yNew)
			{
				board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
				board[x][y] = new BlankPiece();
				return true;
			}
			return false;
		}

		private bool CheckInPositionDiagonal(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			if (Math.Abs(newLocation.X - curLocation.X) != Math.Abs(newLocation.Y - curLocation.Y))
				return false;

			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;
			int xMoveInt = 0;
			int yMoveInt = 0;

			if (newLocation.X > curLocation.X && newLocation.Y > curLocation.Y)
			{
				xMoveInt = 1; yMoveInt = 1;
			}
			else if (newLocation.X > curLocation.X && newLocation.Y < curLocation.Y)
			{
				xMoveInt = 1; yMoveInt = -1;
			}
			else if (newLocation.X < curLocation.X && newLocation.Y > curLocation.Y)
			{
				xMoveInt = -1; yMoveInt = 1;
			}
			else if (newLocation.X < curLocation.X && newLocation.Y < curLocation.Y)
			{
				xMoveInt = -1; yMoveInt = -1;
			}
			int xNew = x + xMoveInt;
			int yNew = y + yMoveInt;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank
				&& !(newLocation.X == xNew && newLocation.Y == yNew))
			{
				xNew += xMoveInt;
				yNew += yMoveInt;
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
