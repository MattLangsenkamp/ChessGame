using ChessGame.Interfaces;
using ChessGame.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.UtilitiesAndFactories
{
	class TextSpriteFactory
	{
		private SpriteFont normalFont;

		private static TextSpriteFactory instance = new TextSpriteFactory();

		public static TextSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private TextSpriteFactory()
		{

		}

		public void LoadAllTextures(ContentManager content)
		{
			normalFont = content.Load<SpriteFont>("EmuLogic");
		}

		public ITextSprite CreateNormalFontTextSpriteSprite()
		{
			return new TextSprite(normalFont);
		}
	}
}
