﻿using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.PieceObjects
{
	class QueenPieceBlack : IChessPiece
	{
		public ChessPieceType.Color Color { get; } = ChessPieceType.Color.Black;
		public ChessPieceType.Type Type { get; } = ChessPieceType.Type.Queen;
		private ISprite pieceSprite;
		public QueenPieceBlack()
		{

		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			pieceSprite.Draw(spriteBatch, location);
		}
	}
}
