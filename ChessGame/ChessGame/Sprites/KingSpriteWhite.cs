using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Sprites
{
	class KingSpriteWhite : ISprite
	{
		private Texture2D texture;
		public KingSpriteWhite(Texture2D t)
		{
			texture = t;
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			throw new NotImplementedException();
		}
	}
}
