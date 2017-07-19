using ChessGame.Interfaces;
using ChessGame.Managers;
using ChessGame.PieceObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using ChessGame.UtilitiesAndFactories;

namespace ChessGame
{
	class BoardManager:IBoardManager
	{
		private Stack<IChessPiece[][]> gameStack;

		private IChessPiece[][] currentBoard;
		private ICommand currentCommand;
		private IChessPiece currentPiece;
		private Vector2 currentLoc;

		private IBoardDrawManager drawManager;
		private IBoardCreatorManager boardCreator;
		private ICheckMateManager checkMateManager;
		private ICursorManager cursorManager;
		private IScoreManager scoreManager;

		private ChessPieceType.Color turnColor;
		private ChessPieceType.Color flipColor;

		private Dictionary<ChessPieceType.Type, ICommand> commandDict;
		private bool clickedOnce;

		public BoardManager()
		{
			drawManager = new BoardDrawManager();
			boardCreator = new BoardCreatorManager();
			cursorManager = new CursorManager();
			checkMateManager = new CheckMateManager(commandDict);
			scoreManager = new ScoreManager();
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
			scoreManager.Draw(spriteBatch, currentBoard);
		}

		/**
		 * method that updates all managers and checks for check/checkmate
		 */
		public void Update()
		{
			Tuple<bool, Vector2> click = cursorManager.Update();
			IChessPiece[][] hypoBoard = boardCreator.CopyBoard(currentBoard);
			bool executeVal = false;
			Vector2 kingLoc = checkMateManager.FindKing(hypoBoard, turnColor);
			Console.WriteLine("here 1 ");
			if (checkMateManager.IsInCheck(hypoBoard, kingLoc))
			{
				Console.WriteLine("here 2");
				if (checkMateManager.IsInCheckMate(hypoBoard, kingLoc))
				{
					Console.WriteLine("here 3");
					Console.WriteLine("checkMate " + turnColor);
				}
			}

			if (click.Item1 == true)
			{
			executeVal = Clicked(click, hypoBoard);
			
				if (executeVal)
				{
					kingLoc = checkMateManager.FindKing(hypoBoard, turnColor);
					if (!checkMateManager.IsInCheck(hypoBoard, kingLoc))
					{
						gameStack.Push(currentBoard);
						currentBoard = hypoBoard;
						clickedOnce = false;
						ChangeTurnColor();
						drawManager.HighLightPiece(new Vector2(-1));
					}
				}
			}
		}

		/**
		 * method that is executed when the mouse is clicked
		 */
		private bool Clicked(Tuple<bool, Vector2> click, IChessPiece[][] hypoBoard)
		{
			bool executeVal = false;
			// if the clicked location is less than the number of squares on the board it is on the board
			// otherwise the click was meant for the side bar
			if ((int)click.Item2.X < Utilities.NumOfSquaresOnBoard)
				executeVal = ClickedOnBoard(click, hypoBoard);
			else
				executeVal = ClickedOnSideBar(click);
			return executeVal;
		}

		/**
		 * method that handles clicks on the board 
		 */ 
		private bool ClickedOnBoard(Tuple<bool, Vector2> click, IChessPiece[][] hypoBoard)
		{
			bool executeVal = false;
			Vector2 clickLoc = DecideVect(click.Item2);
			if (!currentPiece.Equals(currentBoard[(int)clickLoc.X][(int)clickLoc.Y])
				&& turnColor == currentBoard[(int)clickLoc.X][(int)clickLoc.Y].Color)
			{
				drawManager.HighLightPiece(click.Item2);
				currentPiece = currentBoard[(int)clickLoc.X][(int)clickLoc.Y];
				currentLoc = clickLoc;
				currentCommand = commandDict[currentPiece.Type];
				clickedOnce = true;
			}
			else if (clickedOnce == true && turnColor != currentBoard[(int)clickLoc.X][(int)clickLoc.Y].Color)
			{
				executeVal = currentCommand.Execute(hypoBoard, clickLoc, currentLoc);
			}
			return executeVal;
		}

		/**
		 * method that handles clicks on the sidebar of the display
		 */ 
		private bool ClickedOnSideBar(Tuple<bool, Vector2> click)
		{
			ChessPieceType.ClickCommand press = scoreManager.Update(click.Item2);
			if (press == ChessPieceType.ClickCommand.FlipBoard)
				FlipBoard();
			return false; 
		}
		/**
		 * Adds a command to the dictionary
		 */
		public void AddCommand(ICommand com, ChessPieceType.Type key)
		{
			commandDict.Add(key, com);
		}

		/**
		 * method that decides what square was meant to be selected based on 
		 * whose turn it is
		 */
		public Vector2 DecideVect(Vector2 v)
		{
			if (flipColor == ChessPieceType.Color.White)
				return v;
			else
				return new Vector2(7 - v.X, 7 - v.Y);
		}

		/**
		 * Method that changes the turn for all managers
		 */
		private void ChangeTurnColor()
		{
			checkMateManager.ChangeTurn();
			drawManager.ChangeTurn();
			scoreManager.ChangeTurn();
			if (turnColor == ChessPieceType.Color.White)
				turnColor = ChessPieceType.Color.Black;
			else
				turnColor = ChessPieceType.Color.White;
		}

		/**
		 * Flips the way the board is displayed
		 */ 
		private void FlipBoard()
		{
			drawManager.FlipBoard();
			if (flipColor == ChessPieceType.Color.White)
				flipColor = ChessPieceType.Color.Black;
			else
				flipColor = ChessPieceType.Color.White;
		}
	}
}
