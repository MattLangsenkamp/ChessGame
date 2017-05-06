using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Interfaces
{
	public interface IBoardCreatorManager
	{
		IChessPiece[][] BuildBoard();
		void InitializeBoard(IChessPiece[][] board);
		IChessPiece[][] CopyBoard(IChessPiece[][] b);
	}
}
