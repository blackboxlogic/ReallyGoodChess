using System;
using System.Collections.Generic;

namespace Model.Pieces
{
    public class Scissors : BasePiece
    {
		protected override char Char => '✄'; //white scissors (U+2704) //✂ black scissors (U+2702)
        private Vector Front => new Vector(Color == Color.White ? 1 : -1, 0);

        private static Vector[] Directions = new Vector[] { 
            new Vector(-1, 0), // directly left
            new Vector(1, 0),  //directly right
            new Vector(-1, 1),  //top left diag
            new Vector(0, 1),  //directly above
            new Vector(1, 1)   //top right diag
        };

        public override BasePiece[][,] GetMoves(BasePiece[,] board) 
        {
            var boards = new List<BasePiece[,]>();
            //valid moves: 1 square vertically forward,horizontal, or diagonally forward &&  swapping with any team piece. Can only capture like a pawn.

            foreach (Vector v in Directions)  //1 square vertically forward,horizontal, or diagonally forward
            {
                var landed = Location + v;
                if (IsOnBoard(landed)
                    && board[landed.X, landed.Y]?.Color != Color)
                {
                    boards.Add(CloneBoardAndMove<Scissors>(board, landed));
                }
            }

            //capture like pawn
            var forwardLeft = Location + Front + new Vector(0, -1);
            if (IsOnBoard(forwardLeft)
                && board[forwardLeft.X, forwardLeft.Y] != null
                && board[forwardLeft.X, forwardLeft.Y].Color != Color)
            {
                boards.Add(CloneBoardAndMove<Scissors>(board, forwardLeft));
            }
            var forwardRight = Location + Front + new Vector(0, 1);
            if (IsOnBoard(forwardRight)
                && board[forwardRight.X, forwardRight.Y] != null
                && board[forwardRight.X, forwardRight.Y].Color != Color)
            {
                boards.Add(CloneBoardAndMove<Scissors>(board, forwardRight));
            }

            //swapping with teammate pieces
            List<BasePiece> surrounding = getSurroundingPieces(board);
            
            foreach(BasePiece  p in surrounding)
            {
                if(p.Color == Color) //team piece, surrounding, can swap
                {
                    boards.Add(CloneBoardAndSwapMove<Scissors>(board, p.Location)); //swap
                }
            }

            return boards.ToArray();
        }


        public BasePiece[,] CloneBoardAndSwapMove<T>(BasePiece[,] board, Vector landingSpot)
        where T : BasePiece, new()
        {
            var newBoard = Clone(board);

            Type t = newBoard[landingSpot.X, landingSpot.Y].GetType();
            BasePiece nonScissor = (BasePiece) Activator.CreateInstance(t);
            nonScissor.Color = Color;
            nonScissor.HasMoved = true;
            nonScissor.Location = new Vector(Location.X, Location.Y); //nonScissor has location that is the SCISSORS old location.
            newBoard[Location.X, Location.Y] = nonScissor;



            //move scissor to landing
            newBoard[landingSpot.X, landingSpot.Y] =
                new T() { Color = Color, HasMoved = true, Location = landingSpot };

            return newBoard;
        }
    }
}

    
