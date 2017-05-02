using ChessGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Managers
{
	class DrawManager: IDrawManager
	{
		public DrawManager()
		{

		}
		public void Draw(SpriteBatch spriteBatch, IChessPiece[][] board)
		{
			Console.WriteLine("here");
			DrawBoard(spriteBatch);
			DrawPieces(spriteBatch, board);
		}

		private void DrawPieces(SpriteBatch spriteBatch, IChessPiece[][] board)
		{
			Console.WriteLine(board.Length);
			for(int i = 0; i< board.Length;i++)
			{
				for(int j = 0; i < board.Length; j++)
				{
					board[j][i].Draw(spriteBatch, new Vector2(j*SpriteFactory.Instance.PieceWidth, i * SpriteFactory.Instance.PieceHeight));
				}
			}
		}
		private void DrawBoard(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					ISprite curSprite; 
					if(j%2==0)
						if(i%2==0)
							curSprite = SpriteFactory.Instance.MakeMaroonBoardSprite();
						else
							curSprite = SpriteFactory.Instance.MakeTanBoardSprite();
					else 
						if(i%2 != 0)
							curSprite = SpriteFactory.Instance.MakeMaroonBoardSprite();
						else
							curSprite = SpriteFactory.Instance.MakeTanBoardSprite();

					Console.WriteLine("here i "+i+" j "+j);
					Vector2 loc = new Vector2(j * SpriteFactory.Instance.PieceWidth, i * SpriteFactory.Instance.PieceHeight);
					curSprite.Draw(spriteBatch,loc);
				}
			}
		}
	}
}
