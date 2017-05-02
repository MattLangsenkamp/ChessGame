using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Sprites
{
	class RookSpriteBlack : ISprite
	{
		private Texture2D texture;
		private int width;
		private int height;
		public RookSpriteBlack(Texture2D t)
		{
			texture = t;
			height = SpriteFactory.Instance.PieceHeight;
			width = SpriteFactory.Instance.PieceWidth;
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			Rectangle dest = new Rectangle((int)location.X, (int)location.Y, width, height);
			Rectangle source = new Rectangle(4 * width, height, width, height);
			spriteBatch.Draw(texture, dest, source, Color.White);
		}
	}
}