using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Managers
{
	class CursorManager: ICursorManager
	{
		public CursorManager()
		{

		}
		public Tuple<bool,Vector2> Update()
		{
			MouseState ms = Mouse.GetState();
			int block = SpriteFactory.Instance.ScreenDimension / 8;


			if(ms.X / block > 7 || ms.Y / block > 7 || ms.X < 0 || ms.Y < 0)
				return new Tuple<bool, Vector2>(false, new Vector2(0));

			Vector2 retValVect = new Vector2(ms.X/block, ms.Y/block);
			ButtonState clicked = ms.LeftButton;
			bool retValClick = false;
			if (ms.LeftButton == ButtonState.Pressed)
				retValClick = true;
				
			return new Tuple<bool, Vector2>(retValClick, retValVect);;
		}
	}
}
