using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
	interface ICheckMateManager
	{
		bool IsInCheck(IChessPiece[][] board, Vector2 location);
		bool IsInCheckMate(IChessPiece[][] board, Vector2 location);
		Vector2 FindKing(IChessPiece[][] board, ChessPieceType.Color color);
	}
}
