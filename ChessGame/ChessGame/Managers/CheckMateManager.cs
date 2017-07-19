using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ChessGame.Managers
{
	class CheckMateManager:ICheckMateManager
	{
		private Dictionary<ChessPieceType.Type, ICommand> commandDict;
		private ChessPieceType.Color turnColor;
		public CheckMateManager(Dictionary<ChessPieceType.Type, ICommand> dict)
		{
			commandDict = dict;
			turnColor = ChessPieceType.Color.White;
		}
		public void ChangeTurn()
		{
			if (turnColor == ChessPieceType.Color.White)
				turnColor = ChessPieceType.Color.Black;
			else
				turnColor = ChessPieceType.Color.White;
		}

		public Vector2 FindKing(IChessPiece[][] board, ChessPieceType.Color color)
		{
			Vector2 retVal = new Vector2(0);
			for (int y = 0;  y<board.Length; y++)
			{
				for(int x = 0; x<board.Length; x++)
				{
					if (board[x][y].Type == ChessPieceType.Type.King && board[x][y].Color == color)
					{
						retVal = new Vector2(x, y);
						return retVal;
					}
				}
			}
			return retVal;
		}

		public bool IsInCheck(IChessPiece[][] board, Vector2 kingLoc)
		{
			if (HorizontalLeftCheck(board, kingLoc))
				return true;
			else if (HorizontalRightCheck(board, kingLoc))
				return true;
			else if (VerticalDownInCheck(board, kingLoc))
				return true;
			else if (VerticalUpInCheck(board, kingLoc))
				return true;
			else if (DiagonalLeftDownInCheck(board, kingLoc))
				return true;
			else if (DiagonalRightDownInCheck(board, kingLoc))
				return true;
			else if (DiagonalLeftUpInCheck(board, kingLoc))
				return true;
			else if (DiagonalRightUpInCheck(board, kingLoc))
				return true;
			else if (KnightMoveInCheck(board, kingLoc))
				return true;

			return false;
		}
		/**
		 * method that checks if king in kingloc is in checkmate
		 */ 
		public bool IsInCheckMate(IChessPiece[][] board, Vector2 kingLoc)
		{

			int x = (int)kingLoc.X;
			int y = (int)kingLoc.Y;

			int[] places = {x-1, y-1, x, y-1, x + 1, y-1,
				x-1, y, x+1, y,
				x-1, y+1, x, y+1, x + 1, y+1};

			for (int i = 0; i < 16; i += 2)
			{
				if (IsOnBoard(board, new Vector2(places[i], places[i + 1]))
					&& !IsInCheck(board, new Vector2(places[i], places[i + 1]))
					&& board[places[i]][places[i + 1]].Color == ChessPieceType.Color.Blank)
				{
					Console.WriteLine("here"+ places[i]+"  "+places[i + 1]);
					return false;
				}
			}

			if (CanPieceObstruct(board, kingLoc))
				return false;

			return true;
		}

		private bool HorizontalRightCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int xNew = x + 1;

			if (IsOnBoard(board, new Vector2(xNew, y)))
				if(IsEnemyInPosition(board, new Vector2(xNew, y), turnColor))
					if (board[xNew][y].Type == ChessPieceType.Type.King)
						return true;
			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew++;
			}

			if (IsOnBoard(board, new Vector2(xNew, y)))
				if (IsEnemyInPosition(board, new Vector2(xNew, y), turnColor))
					if (board[xNew][y].Type == ChessPieceType.Type.Rook || board[xNew][y].Type == ChessPieceType.Type.Queen)
						return true;
			return false;
		}
		private bool HorizontalLeftCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int xNew = x - 1;

			if (IsOnBoard(board, new Vector2(xNew, y)))
				if (IsEnemyInPosition(board, new Vector2(xNew, y), turnColor))
					if (board[xNew][y].Type == ChessPieceType.Type.King)
						return true;
			while (IsOnBoard(board, new Vector2(xNew, y)) && board[xNew][y].Color == ChessPieceType.Color.Blank)
			{
				xNew--;
			}

			if (IsOnBoard(board, new Vector2(xNew, y)))
				if (IsEnemyInPosition(board, new Vector2(xNew, y), turnColor))
					if (board[xNew][y].Type == ChessPieceType.Type.Rook || board[xNew][y].Type == ChessPieceType.Type.Queen)
						return true;
			return false;
		}

		private bool VerticalUpInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y - 1;

			if (IsOnBoard(board, new Vector2(x, yNew)))
				if (IsEnemyInPosition(board, new Vector2(x, yNew), turnColor))
					if (board[x][yNew].Type == ChessPieceType.Type.King)
						return true;

			while (IsOnBoard(board, new Vector2(x, yNew)) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
			}

			if (IsOnBoard(board, new Vector2(x, yNew)))
				if(IsEnemyInPosition(board, new Vector2(x, yNew), turnColor))
					if (board[x][yNew].Type == ChessPieceType.Type.Rook || board[x][yNew].Type == ChessPieceType.Type.Queen)
						return true;
			return false;
		}

		private bool VerticalDownInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y + 1;

			if (IsOnBoard(board, new Vector2(x, yNew)))	
				if(IsEnemyInPosition(board, new Vector2(x, yNew), turnColor))
					if (board[x][yNew].Type == ChessPieceType.Type.King)
						return true;

			while (IsOnBoard(board, new Vector2(x, yNew)) && board[x][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
			}

			if (IsOnBoard(board, new Vector2(x, yNew)))
				if (IsEnemyInPosition(board, new Vector2(x, yNew), turnColor))
					if (board[x][yNew].Type == ChessPieceType.Type.Rook || board[x][yNew].Type == ChessPieceType.Type.Queen)
						return true;
			return false;
		}
		private bool DiagonalRightDownInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y + 1;
			int xNew = x + 1;
			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if (IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.King)
						return true;
					else if (board[xNew][yNew].Type == ChessPieceType.Type.Pawn && turnColor == ChessPieceType.Color.Black)
					return true;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
				xNew++;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if (IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
						return true;
				
			return false;
		}
		private bool DiagonalLeftDownInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y + 1;
			int xNew = x - 1;
			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if(IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.King)
						return true;
					else if (board[xNew][yNew].Type == ChessPieceType.Type.Pawn && turnColor == ChessPieceType.Color.Black)
						return true;
			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew++;
				xNew--;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if(IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
						return true;
			return false;
		}

		private bool DiagonalRightUpInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y - 1;
			int xNew = x + 1;

			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if (IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.King)
						return true;
					else if (board[xNew][yNew].Type == ChessPieceType.Type.Pawn && turnColor == ChessPieceType.Color.White)
						return true;

			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
				xNew++;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if (IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
						return true;
			return false;
		}
		private bool DiagonalLeftUpInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int yNew = y - 1;
			int xNew = x - 1;
			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if(IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.King)
						return true;
					else if (board[xNew][yNew].Type == ChessPieceType.Type.Pawn && turnColor == ChessPieceType.Color.White)
						return true;
			

			while (IsOnBoard(board, new Vector2(xNew, yNew)) && board[xNew][yNew].Color == ChessPieceType.Color.Blank)
			{
				yNew--;
				xNew--;
			}

			if (IsOnBoard(board, new Vector2(xNew, yNew)))
				if (IsEnemyInPosition(board, new Vector2(xNew, yNew), turnColor))
					if (board[xNew][yNew].Type == ChessPieceType.Type.Bishop || board[xNew][yNew].Type == ChessPieceType.Type.Queen)
						return true;
			return false;
		}

		private bool KnightMoveInCheck(IChessPiece[][] board, Vector2 location)
		{
			int x = (int)location.X;
			int y = (int)location.Y;
			int[] xNews = { x - 1, x + 1, x + 2, x + 2, x + 1, x - 1, x - 2, x - 2 };
			int[] yNews = { y - 2, y - 2, y - 1, y + 1, y + 2, y + 2, y + 1, y - 1 };
			int counter = 0;
			for(int i = 0; i<board.Length;i++)
			{
				if (IsOnBoard(board, new Vector2(xNews[counter], yNews[counter])) &&
					board[xNews[counter]][yNews[counter]].Type == ChessPieceType.Type.Knight)
						return true;
			}
			
			return false;
		}
		private bool IsOnBoard(IChessPiece[][] board, Vector2 location)
		{
			if (location.X >= board.Length || location.X < 0)
				return false;
			if (location.Y >= board.Length || location.Y < 0)
				return false;
			return true;
		}

		/*
		 * takes the team color and location and checks to see if an enemy of the entered team 
		 * color is in the
		 */
		private bool IsEnemyInPosition(IChessPiece[][] board, Vector2 l, ChessPieceType.Color teamColor)
		{
			if (board[(int)l.X][(int)l.Y].Color == teamColor || board[(int)l.X][(int)l.Y].Color == ChessPieceType.Color.Blank)
				return false;
			return true;
		}
		private bool CanPieceObstruct(IChessPiece[][] board, Vector2 kingLoc)
		{
			for(int y = 0; y<board.Length;y++)
				for (int x = 0; x < board.Length; x++)
				{
					IChessPiece curPiece = board[x][y];
					if (!IsEnemyInPosition(board, new Vector2(x,y),turnColor) &&
						CanObstructRedirect(board, kingLoc, new Vector2(x,y), curPiece))
						return true;
				}
			return false;
		}
		private bool CanObstructRedirect(IChessPiece[][] board, Vector2 kingLoc, Vector2 newLoc, IChessPiece curPiece)
		{
			switch (curPiece.Type)
			{
				case ChessPieceType.Type.Bishop:
					return CanBishopObstruct(board, kingLoc, newLoc);
				case ChessPieceType.Type.Blank:
					return false;
				case ChessPieceType.Type.King:
					return false;
				case ChessPieceType.Type.Knight:
					return CanKnightObstruct(board, kingLoc, newLoc);
				case ChessPieceType.Type.Pawn:
					return CanPawnObstruct(board, kingLoc, newLoc);
				case ChessPieceType.Type.Queen:
					return CanQueenObstruct(board, kingLoc, newLoc);
				case ChessPieceType.Type.Rook:
					return CanRookObstruct(board, kingLoc, newLoc);
				default:
					return false;
			}
		}
		private bool CanBishopObstruct(IChessPiece[][] board, Vector2 kingLoc, Vector2 pieceLoc)
		{
			for (int y = 0; y < board.Length; y++)
				for (int x = 0; x < board.Length; x++)
				{
					bool moveSuccessful = commandDict[ChessPieceType.Type.Bishop].Execute(board, new Vector2(x,y), pieceLoc);
					if (moveSuccessful && !IsInCheck(board, kingLoc))
					{
						SwapPieces(board,pieceLoc, new Vector2(x,y));
						return true;
					}
					else if (moveSuccessful)
						SwapPieces(board,pieceLoc, new Vector2(x,y));
				}
			return false;
		}
		private bool CanRookObstruct(IChessPiece[][] board, Vector2 kingLoc, Vector2 pieceLoc)
		{
			for (int y = 0; y < board.Length; y++)
				for (int x = 0; x < board.Length; x++)
				{
					bool moveSuccessful = this.commandDict[ChessPieceType.Type.Rook].Execute(board, new Vector2(x, y), pieceLoc);
					if (moveSuccessful && !IsInCheck(board, kingLoc))
					{
						SwapPieces(board,pieceLoc, new Vector2(x,y));
						return true;
					}
					else if (moveSuccessful)
						SwapPieces(board,pieceLoc, new Vector2(x,y));
				}
			return false;
		}
		private bool CanPawnObstruct(IChessPiece[][] board, Vector2 kingLoc, Vector2 pieceLoc)
		{
			for (int y = 0; y < board.Length; y++)
				for (int x = 0; x < board.Length; x++)
				{
					bool moveSuccessful = commandDict[ChessPieceType.Type.Pawn].Execute(board, new Vector2(x, y), pieceLoc);
					if (moveSuccessful && !IsInCheck(board, kingLoc))
					{
						SwapPieces(board,pieceLoc, new Vector2(x,y));
						return true;
					}
					else if(moveSuccessful)
						SwapPieces(board,pieceLoc, new Vector2(x,y));

				}
			return false;
		}
		private bool CanKnightObstruct(IChessPiece[][] board, Vector2 kingLoc, Vector2 pieceLoc)
		{
			int x = (int)pieceLoc.X;
			int y = (int)pieceLoc.Y;
			int[] xNews = { x - 1, x + 1, x + 2, x + 2, x + 1, x - 1, x - 2, x - 2 };
			int[] yNews = { y - 2, y - 2, y - 1, y + 1, y + 2, y + 2, y + 1, y - 1 };
			int counter = 0;
			for (int i = 0; i < board.Length; i++)
			{
				if (IsOnBoard(board, new Vector2(xNews[counter], yNews[counter])))
				{
					bool moveSuccessful = commandDict[ChessPieceType.Type.Knight].Execute(board, new Vector2(xNews[counter], yNews[counter]), pieceLoc);
					if (moveSuccessful && !IsInCheck(board, kingLoc))
					{
						SwapPieces(board, pieceLoc, new Vector2(xNews[counter], yNews[counter]));
						return true;
					}
					else if (moveSuccessful)
						SwapPieces(board, pieceLoc, new Vector2(xNews[counter], yNews[counter]));
				}
			}
			return false;
		}
		private bool CanQueenObstruct(IChessPiece[][] board, Vector2 kingLoc, Vector2 pieceLoc)
		{
			for (int y = 0; y < board.Length; y++)
				for (int x = 0; x < board.Length; x++)
				{
					bool moveSuccessful = commandDict[ChessPieceType.Type.Queen].Execute(board, new Vector2(x, y), pieceLoc);
					if (moveSuccessful && !IsInCheck(board, kingLoc))
					{
						SwapPieces(board,pieceLoc, new Vector2(x,y));
						return true;
					}
					else if (moveSuccessful)
						SwapPieces(board,pieceLoc, new Vector2(x,y));
				}
			return false;
		}

		private void SwapPieces(IChessPiece[][] board, Vector2 loc1, Vector2 loc2)
		{
			IChessPiece temp1 = board[(int)loc1.X][(int)loc1.Y];
			IChessPiece temp2 = board[(int)loc2.X][(int)loc2.Y];
			board[(int)loc1.X][(int)loc1.Y] = temp2;
			board[(int)loc2.X][(int)loc2.Y] = temp1;
		}
	}
}
