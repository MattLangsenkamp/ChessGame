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
	class RookMoveCommand:CommandAbstractClass
	{
		public override bool Execute(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			if (!IsOnBoard(board, newLocation))
				return false;
			if (IsTeamMateInPosition(board, newLocation, board[(int)curLocation.X][(int)curLocation.Y].Color))
				return false;

			int x = (int)curLocation.X;
			int y = (int)curLocation.Y;
			int xNew = x + 1;
			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew++;
			}
			xNew = x - 1;


			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew--;
			}
			return true;
		}

	}
}
