using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using ChessGame.PieceObjects;

namespace ChessGame.Commands
{
	class PawnMoveCommand:CommandAbstractClass
	{
		public override bool Execute(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			if (!IsOnBoard(board, newLocation))
				return false;
			if (IsTeamMateInPosition(board, newLocation, board[(int)curLocation.X][(int)curLocation.Y].Color))
				return false;

			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;
			int[] xNews = { x-1, x, x+1, x-1, x, x+1};
			int[] yNews = { y+1, y+1, y+1, y-1, y-1, y-1};

			for(int i = 0; i<xNews.Length; i++)
			{
				if ((int)newLocation.X == xNews[i] && (int)newLocation.Y == yNews[i])
				{
					board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
					board[x][y] = new BlankPiece();
					return true;
				}
			}

			return false;
		}
	}
}
