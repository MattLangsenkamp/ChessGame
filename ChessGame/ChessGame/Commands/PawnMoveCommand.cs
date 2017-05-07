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
			if (board[(int)curLocation.X][(int)curLocation.Y].Color == ChessPieceType.Color.Black && newLocation.Y < curLocation.Y)
				return false;
			if (board[(int)curLocation.X][(int)curLocation.Y].Color == ChessPieceType.Color.White && newLocation.Y > curLocation.Y)
				return false;
			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;
			int[] xNewsD = { x-1, x+1, x-1, x+1};
			int[] yNewsD = { y+1, y+1, y-1, y-1};
			int[] xNewsS = { x, x };
			int[] yNewsS = { y - 1, y + 1 };
			int[] xNewsF = { x, x };
			int[] yNewsF = { y - 2, y + 2 };

			for (int i = 0; i<xNewsD.Length; i++)
			{
				if ((int)newLocation.X == xNewsD[i] && (int)newLocation.Y == yNewsD[i])
				{
					if (IsEnemyInPosition(board, newLocation, board[(int)curLocation.X][(int)curLocation.Y].Color))
					{
						board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
						board[x][y] = new BlankPiece();
						ChangeMoveStatus(board, curLocation);
						return true;
					}
				}
			}
			for (int i = 0; i < xNewsS.Length; i++)
			{
				if ((int)newLocation.X == xNewsS[i] && (int)newLocation.Y == yNewsS[i])
				{
					if (!IsEnemyInPosition(board, newLocation,board[(int)curLocation.X][(int)curLocation.Y].Color))
					{ 
						board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
						board[x][y] = new BlankPiece();
						ChangeMoveStatus(board,curLocation);
						return true;
					}
				}
			}

			for (int i = 0; i < xNewsF.Length; i++)
			{
				if ((int)newLocation.X == xNewsF[i] && (int)newLocation.Y == yNewsF[i])
				{
					if (!IsEnemyInPosition(board, newLocation, board[(int)curLocation.X][(int)curLocation.Y].Color) && board[(int)curLocation.X][(int)curLocation.Y].FirstMove)
					{
						ChangeMoveStatus(board, curLocation);
						board[(int)newLocation.X][(int)newLocation.Y] = board[x][y];
						board[x][y] = new BlankPiece();				
						return true;
					}
				}
			}
			return false;
		}
	}
}
