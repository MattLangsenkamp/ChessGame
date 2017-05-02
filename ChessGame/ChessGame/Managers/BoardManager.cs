using ChessGame.Interfaces;
using ChessGame.Managers;
using ChessGame.PieceObjects;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
	class BoardManager:IBoardManager
	{
		private Stack<IChessPiece[][]> gameStack;
		private IChessPiece[][] currentBoard;
		private IDrawManager drawManager;
		private IBoardCreatorManager boardCreator;
		public BoardManager()
		{
			drawManager = new DrawManager();
			boardCreator = new BoardCreatorManager();
			currentBoard = boardCreator.BuildBoard();
			boardCreator.InitializeBoard(currentBoard);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			drawManager.Draw(spriteBatch, currentBoard);
		}	

		public void Update()
		{
			
		}
	}
}
