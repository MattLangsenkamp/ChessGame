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
	class QueenSpriteBlack : ISprite
	{
		private Texture2D texture;
		public QueenSpriteBlack(Texture2D t)
		{
			texture = t;
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			throw new NotImplementedException();
		}
	}
}