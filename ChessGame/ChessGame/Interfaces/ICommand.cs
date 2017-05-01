using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
	interface ICommand
	{
		bool Execute(int x, int y);
		bool IsOnBoard(int x, int y);
		bool IsEnemyInPosition(int x, int y, ChessPieceType.Color curColor);
		bool IsTeamMateInPosition(int x, int y, ChessPieceType.Color curColor);
	}
}
