using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
	interface IScoreManager
	{
		void PieceTaken(ChessPieceType.Color teamColor, ChessPieceType.Type pieceType);
		void Draw(SpriteBatch spriteBatch, IChessPiece[][] board);
		ChessPieceType.ClickCommand Update(Vector2 location);
		void ChangeTurn();
	}
}
