using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Buttons
{
	class ArrowButton
	{
		private ISprite arrowSprite;
		private Vector2 buttonLoc;
		public ArrowButton(ChessPieceType.Direction direction, Vector2 location)
		{
			buttonLoc = location;
			if (direction == ChessPieceType.Direction.Left)
				arrowSprite = SpriteFactory.Instance.MakeLeftArrowSprite();
			else
				arrowSprite = SpriteFactory.Instance.MakeRightArrowSprite();
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			arrowSprite.Draw(spriteBatch, buttonLoc);
		}
	}
}
