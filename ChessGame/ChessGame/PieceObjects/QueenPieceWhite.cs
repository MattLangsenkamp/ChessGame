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
	class QueenPieceWhite:IChessPiece
	{
		public ChessPieceType.Color Color { get; } = ChessPieceType.Color.White;
		public ChessPieceType.Type Type { get; } = ChessPieceType.Type.Queen;
		public bool FirstMove { get; set; } = true;
		private ISprite pieceSprite;
		public QueenPieceWhite()
		{
			pieceSprite = SpriteFactory.Instance.MakeQueenSpriteWhite();
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			pieceSprite.Draw(spriteBatch, location);
		}
	}
}
