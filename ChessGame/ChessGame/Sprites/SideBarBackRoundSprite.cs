using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChessGame.UtilitiesAndFactories;

namespace ChessGame.Sprites
{
	class SideBarBackRoundSprite : ISprite
	{
		Texture2D texture;
		public SideBarBackRoundSprite(Texture2D t)
		{
			texture = t;
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			Rectangle rect = new Rectangle((int)location.X, (int)location.Y, Utilities.PieceWidth*2, Utilities.PieceHeight*8);
			Rectangle source = new Rectangle((int)location.X, (int)location.Y, 0, 0);
			spriteBatch.Draw(texture, rect, source, Color.Black);
		}
	}
}
