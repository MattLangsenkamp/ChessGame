using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.PieceObjects
{
	class BlankPiece:IChessPiece
	{
		public ChessPieceType.Color Color { get; } = ChessPieceType.Color.Blank;
		public ChessPieceType.Type Type { get; } = ChessPieceType.Type.Blank;
		//private ISprite pieceSprite;
		public BlankPiece()
		{
			
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			
		}
	}
}
