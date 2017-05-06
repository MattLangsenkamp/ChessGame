using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
	interface ICommand
	{
		bool Execute(IChessPiece[][] board, Vector2 newLocation, Vector2 curLocation);
		bool IsOnBoard(IChessPiece[][] board, Vector2 location);
		bool IsEnemyInPosition(IChessPiece[][] board, Vector2 l, ChessPieceType.Color teamColor);
		bool IsTeamMateInPosition(IChessPiece[][] board, Vector2 l, ChessPieceType.Color curColor);
	}
}
