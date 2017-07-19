using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.UtilitiesAndFactories
{
	public static class Utilities
	{
		public static int NumOfSquaresOnBoard { get; } = 8;
		public static int ScreenDimensionX { get; } = 880;
		public static int ScreenDimensionY { get; } = 704;
		public static int PieceWidth { get; } = 333;
		public static int PieceHeight { get; } = 333;

	}
}
