using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
	public interface IChessPiece
	{
		ChessPieceType.Color Color {get;}
		ChessPieceType.Type Type { get; }
		bool FirstMove { get; set; }
		void Draw(SpriteBatch spriteBatch, Vector2 Location);
	}
}
