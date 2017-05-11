using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
	interface IBoardDrawManager
	{
		void Draw(SpriteBatch spriteBatch, IChessPiece[][] board);
		void HighLightPiece(Vector2 vect);
		void ChangeTurn();
	}
}
