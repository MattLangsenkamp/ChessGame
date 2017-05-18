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
	class ArrowSpriteLeft: ISprite
	{
		private Texture2D texture;
		private Rectangle dest;
		public ArrowSpriteLeft(Texture2D t)
		{
			texture = t;
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			dest = new Rectangle((int)location.X, (int)location.Y, texture.Width, texture.Height);
			spriteBatch.Draw(texture, dest, Color.White);
		}
	}
}
