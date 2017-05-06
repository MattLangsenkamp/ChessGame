using ChessGame.Interfaces;
using ChessGame.PieceObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Commands
{
	class KnightMoveCommand : CommandAbstractClass
	{
		public override bool Execute(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			if (!IsOnBoard(board, newLocation))
				return false;
			if (IsTeamMateInPosition(board, newLocation, board[(int)curLocation.X][(int)curLocation.Y].Color))
				return false;

			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;
			int[] xNews = { x - 1, x + 1, x + 2, x + 2, x + 1, x - 1, x - 2, x - 2 };
			int[] yNews = { y - 2, y - 2, y - 1, y + 1, y + 2, y + 2, y + 1, y - 1 };
			for (int i = 0; i < xNews.Length; i++)
			{
				if ((int)newLocation.X == xNews[i] && (int)newLocation.Y == yNews[i])
				{
					board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
					board[x][y] = new BlankPiece();
					return true;
				}
			}
			return false;

			return true;
		}
	}
}
