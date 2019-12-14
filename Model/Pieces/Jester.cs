using System;
using System.Collections.Generic;

namespace Model.Pieces
{
	public class Jester : BasePiece
	{
		protected override char Char => '※';

		private static Vector[] DirectionsDiagonal = new Vector[] 
		{ 
			new Vector(-1, 1),
			new Vector( 1, 1),
			new Vector(-1,-1),
			new Vector( 1,-1) 
		};

		private static Vector[] DirectionsUpDownLeftRight = new Vector[]
		{
			new Vector( 0, 1),
			new Vector( 0,-1),
			new Vector(-1, 0),
			new Vector( 1, 0) 
		};
		
		public override BasePiece[][,] GetMoves(BasePiece[,] board)
		{
			var boards = new List<BasePiece[,]>();

			Action<Vector> MoveAndCheck = d =>
			{
				var firsthop = Location + d;

				if (IsOnBoard(firsthop) && board[firsthop.X, firsthop.Y] == null)
				{
					var secondhop = firsthop + d;

					if (IsOnBoard(secondhop) && (board[secondhop.X, secondhop.Y] != null))
					{
						if (board[secondhop.X, secondhop.Y]?.Color != Color)
						{
							boards.Add(CloneBoardAndMove<Jester>(board, secondhop));
						}
					}
					else
					{
						foreach (Vector n in DirectionsUpDownLeftRight)
						{
							var landed = secondhop + n;

							if (IsOnBoard(landed) && board[landed.X, landed.Y]?.Color != Color)
							{
								boards.Add(CloneBoardAndMove<Jester>(board, landed));
							}
						}					
					}
				}
			};

			foreach (Vector d in DirectionsDiagonal)
			{
				MoveAndCheck(d);
			}

			return boards.ToArray();
		}
	}
}