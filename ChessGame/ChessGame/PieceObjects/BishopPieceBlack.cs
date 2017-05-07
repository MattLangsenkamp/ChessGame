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
	class BishopPieceBlack : IChessPiece
	{
		public ChessPieceType.Color Color { get; } = ChessPieceType.Color.Black;
		public ChessPieceType.Type Type { get; } = ChessPieceType.Type.Bishop;
		public bool FirstMove { get; set; } = true;

		private ISprite pieceSprite;
		public BishopPieceBlack()
		{
			pieceSprite = SpriteFactory.Instance.MakeBishopSpriteBlack();
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			pieceSprite.Draw(spriteBatch, location);
		}
	}
}
