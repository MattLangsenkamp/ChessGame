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
		private Vector2 currentLoc;
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
			checkMateManager = new CheckMateManager();
			gameStack = new Stack<IChessPiece[][]>();
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
			Vector2 clickLoc = DecideVect(click.Item2);
			if (click.Item1 == true)
			{
				if (!currentPiece.Equals(currentBoard[(int)clickLoc.X][(int)clickLoc.Y])
					&& turnColor == currentBoard[(int)clickLoc.X][(int)clickLoc.Y].Color)
				{
					drawManager.HighLightPiece(click.Item2);
					currentPiece = currentBoard[(int)clickLoc.X][(int)clickLoc.Y];
					currentLoc = clickLoc;
					currentCommand = commandDict[currentPiece.Type];
					clickedOnce = true;
				} else if (clickedOnce == true && turnColor != currentBoard[(int)clickLoc.X][(int)clickLoc.Y].Color)
				{
					executeVal = currentCommand.Execute(hypoBoard, clickLoc, currentLoc);
				}				
			}
			if (executeVal)
			{
				Vector2 kingLoc = checkMateManager.FindKing(hypoBoard, turnColor);
				if (!checkMateManager.IsInCheck(hypoBoard, kingLoc))
				{
					gameStack.Push(currentBoard);
					Console.WriteLine("Stack Count "+gameStack.Count);
					currentBoard = hypoBoard;
					clickedOnce = false;
					ChangeTurnColor();
					drawManager.HighLightPiece(new Vector2(-1));
				}
			}
		}
		public void AddCommand(ICommand com, ChessPieceType.Type key)
		{
			commandDict.Add(key, com);
		}

		public Vector2 DecideVect(Vector2 v)
		{
			if (turnColor == ChessPieceType.Color.White)
				return v;
			else
				return new Vector2(7 - v.X, 7 - v.Y);
		}

		private void ChangeTurnColor()
		{
			checkMateManager.ChangeTurn();
			drawManager.ChangeTurn();
			if (turnColor == ChessPieceType.Color.White)
				turnColor = ChessPieceType.Color.Black;
			else
				turnColor = ChessPieceType.Color.White;
		}
	}
}
