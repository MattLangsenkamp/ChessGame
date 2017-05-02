using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame.Commands
{
	public abstract class CommandAbstractClass : ICommand
	{
		protected IChessPiece[][] board;

		public bool IsEnemyInPosition(int x, int y, ChessPieceType.Color curColor)
		{
			if (board[x][y].Color == curColor || board[x][y].Color == ChessPieceType.Color.Blank)
				return false;
			return true;
		}

		public bool IsOnBoard(int x, int y)
		{
			if (x > board.Length || x < 0)
				return false;
			if (y > board.Length || y < 0)
				return false;
			return true;
		}

		public bool IsTeamMateInPosition(int x, int y, ChessPieceType.Color curColor)
		{
			if (board[x][y].Color == curColor)
				return true;
			return false;
		}

		public virtual bool Execute(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
