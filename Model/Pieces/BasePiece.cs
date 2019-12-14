using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
	public abstract class BasePiece
	{
		public bool HasMoved;
		public Color Color;
		public Vector Location;

		public abstract BasePiece[][,] GetMoves(BasePiece[,] board);
		private const char ToBlackChar = (char)('♚' - '♔');
		protected abstract char Char { get; } // ♔♕♖♗♘♙ KQRBNP

		public char AsColoredChar()
		{
			return (char)(Char + (int)Color * ToBlackChar);
		}

		protected bool IsOnBoard(Vector landed)
		{
			return landed.X >= 0 && landed.X <= 7 && landed.Y >= 0 && landed.Y <= 7;
		}

		protected BasePiece[,] Clone(BasePiece[,] board)
		{
			return (BasePiece[,])board.Clone(); // Shallow Copy
		}

		protected BasePiece[,] CloneBoardAndMove<T>(BasePiece[,] board, Vector landingSpot)
			where T : BasePiece, new()
		{
			var newBoard = Clone(board);
			//remove from where it was
			newBoard[Location.X, Location.Y] = null;
			//put in new place
			newBoard[landingSpot.X, landingSpot.Y] =
				new T() { Color = Color, HasMoved = true, Location = landingSpot };
			return newBoard;
		}

		protected List<BasePiece> getSurroundingPieces(BasePiece[,] board)
		{	
			Vector[] Directions = new Vector[] { //all 8 directions from current location
            new Vector(-1, -1), // bottom left diag
            new Vector(0, -1), // directly below
            new Vector(1, -1), // bottom right diag
            new Vector(-1, 0), // directly left
            new Vector(1, 0),  //directly right
            new Vector(-1, 1),  //top left diag
            new Vector(0, 1),  //directly above
            new Vector(1, 1)   //top right diag
        };

			List<BasePiece> pList = new List<BasePiece>();
			
			foreach(Vector v in Directions)
			{
				var surround = Location + v;
				if (IsOnBoard(surround) && board[surround.X, surround.Y] != null)  //on board, and there is a piece occupying
				{
					pList.Add(board[surround.X,surround.Y]); //add  that piece (it's surrounding)
				}
			}

			return pList; //return the surrounding palyers
		}
	}
}
