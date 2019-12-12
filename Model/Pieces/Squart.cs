using System;
using System.Collections.Generic;

namespace Model.Pieces
{
	public class Squart : BasePiece // A typo of square that I left as the name
	                               //It can move in square or one random position on the board
	{
		protected override char Char => '�';

		private static Vector[] Directions = new Vector[] {
			new Vector(1, 1),
			new Vector(-1, 1),
			new Vector(1, -1),
			new Vector(-1, -1),
			new Vector(0, 1),
			new Vector(0, -1),
			new Vector(-1, 0),
			new Vector(1, 0)	
		};

		public override BasePiece[][,] GetMoves(BasePiece[,] board)
		{
			// make an array size 8
			var boards = new List<BasePiece[,]>();

			// add things to it
			foreach (var direction in Directions)
			{
				var landed = Location + direction;

				if (IsOnBoard(landed)
					&& board[landed.X, landed.Y]?.Color != Color) {
					boards.Add(CloneBoardAndMove<Squart>(board, landed));
				}
			}
			
			//making the rng random position
			var rng = new Random();
			var randX = rng.Next(0, 7) - Location.X;
			var randY = rng.Next(0, 7) - Location.Y;
			
			Vector randDirection = new Vector(randX,randY);

			var rngLanded = Location + randDirection;
			
			if (IsOnBoard(rngLanded)
			    && board[rngLanded.X, rngLanded.Y]?.Color != Color) {
				boards.Add(CloneBoardAndMove<Squart>(board, rngLanded));
			}	
			
			return boards.ToArray();
		}
	}
}
