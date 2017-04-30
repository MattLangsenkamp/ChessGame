using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Commands
{
	class IsCheckMateCommand:CommandAbstractClass
	{
		public IsCheckMateCommand(IChessPiece[][] b)
		{
			board = b;
		}
	}
}
