using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame.Commands
{
	public abstract class CommandAbstractClass : ICommand
	{

		public bool IsEnemyInPosition(IChessPiece[][] board, Vector2 l, ChessPieceType.Color teamColor)
		{
			if (board[(int)l.X][(int)l.Y].Color == teamColor || board[(int)l.X][(int)l.Y].Color == ChessPieceType.Color.Blank)
				return false;
			return true;
		}

		public bool IsOnBoard(IChessPiece[][] board, Vector2 location)
		{
			if (location.X >= board.Length || location.X < 0)
				return false;
			if (location.Y >= board.Length || location.Y < 0)
				return false;
			return true;
		}
		

		public virtual bool IsTeamMateInPosition(IChessPiece[][] board, Vector2 l, ChessPieceType.Color curColor)
		{
			if (board[(int)l.X][(int)l.Y].Color == curColor)
				return true;
			return false;
		}

		public virtual bool Execute(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation)
		{
			return true;
		}
		protected void ChangeMoveStatus(IChessPiece[][] board, Vector2 l)
		{
			board[(int)l.X][(int)l.Y].FirstMove = false;
		}
	}
}
