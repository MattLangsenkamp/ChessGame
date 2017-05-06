using ChessGame.Interfaces;
using ChessGame.Managers;
using ChessGame.PieceObjects;
using Microsoft.Xna.Framework;
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
		private ICommand currentCommand;
		private IChessPiece currentPiece;
		private IDrawManager drawManager;
		private IBoardCreatorManager boardCreator;
		private ICheckMateManager checkMateManager;
		private ICursorManager cursorManager;
		private ChessPieceType.Color turnColor;
		private Dictionary<ChessPieceType.Type, ICommand> commandDict;
		private bool clickedOnce;

		public BoardManager()
		{
			drawManager = new DrawManager();
			boardCreator = new BoardCreatorManager();
			cursorManager = new CursorManager();
			currentBoard = boardCreator.BuildBoard();
			boardCreator.InitializeBoard(currentBoard);
			commandDict = new Dictionary<ChessPieceType.Type, ICommand>();
			currentPiece = currentBoard[4][4];
			turnColor = ChessPieceType.Color.White;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			drawManager.Draw(spriteBatch, currentBoard);
		}	

		public void Update()
		{
			Tuple<bool, Vector2> click = cursorManager.Update();
			IChessPiece[][] hypoBoard = boardCreator.CopyBoard(currentBoard);
			bool executeVal = false;
			if (click.Item1 == true)
			{
				drawManager.HighLightPiece(click.Item2);
				if (!currentPiece.Equals(currentBoard[(int)click.Item2.X][(int)click.Item2.Y])
					&& turnColor == currentBoard[(int)click.Item2.X][(int)click.Item2.Y].Color)
				{
					currentPiece = currentBoard[(int)click.Item2.X][(int)click.Item2.Y];
					Console.WriteLine("first "+(int)click.Item2.X + " " + (int)click.Item2.Y);	
					//currentCommand = commandDict[currentPiece.Type];
					clickedOnce = true;
				} else if (clickedOnce == true && turnColor != currentBoard[(int)click.Item2.X][(int)click.Item2.Y].Color)
				{
					Console.WriteLine("second " + (int)click.Item2.X + " " + (int)click.Item2.Y);
					//executeVal = currentCommand.Execute(hypoBoard, click.Item2);
					clickedOnce = false;
				}				
			}
			if (executeVal)
			{
				Vector2 kingLoc = checkMateManager.FindKing(hypoBoard, turnColor);
				if (checkMateManager.IsInCheck(hypoBoard, kingLoc))
				{
					gameStack.Push(currentBoard);
					currentBoard = hypoBoard;
				}
			}
		}
	}
}
