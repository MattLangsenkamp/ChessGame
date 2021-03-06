﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
	public class ChessPieceType
	{
		public enum Color { White, Black, Blank}
		public enum BoardColor { Maroon, Tan }
		public enum Type { King, Queen, Knight, Bishop, Rook, Pawn, Blank}
		public enum Direction { Left, Right }
		public enum ClickCommand { PreviousBoard, NextBoard, FlipBoard, NoClick }
	}
}
