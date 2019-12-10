using System;
using System.Collections.Generic;
//PawnDispensingBombAssassin 
//  cannot capture pieces
//  can only move by swapping location with a friendly piece
//  can create a pawn somewhere in front stopping at collision
//  can self destruct killing all units around it (including itself and teammates)
{
    public class PawnDispensingBombAssassin : BasePiece
    {
        protected override char Char => '☠';
        private Vector Front => new Vector(Color == Color.White ? 1 :-1, 0);
        private List<Vector> Surroundings = [
            new Vector(-1,-1),
            new Vector(-1,0),
            new Vector(-1,1),
            new Vector(0,-1),
            new Vector(0,1),
            new Vector(1,1),
            new Vector(1,0),
            new Vector(1,-1),
            new Vector(0,0) //The piece sacrifices itself for the greater good
        ]
        
        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            var boards = new List<BasePiece[,]>();

			Action<Vector> continueDirection = d =>
			{
				bool captured = false;
                var looking = Location + d;
				while (IsOnBoard(looking) && board[looking.X, looking.Y]?.Color != Color && !captured)
				{
					captured = board[looking.X, looking.Y] != null;
					boards.Add(CloneBoardAndMove<Bishop>(board, looking));
                    looking += d;
				}
			};

            continueDirection(Front);
            
            foreach(Vector v in Surroundings){
                var looking = Location + v;
                board[looking.X,looking.Y] = null;
            }

			return boards.ToArray();
        }
    }
}
