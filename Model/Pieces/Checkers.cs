using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Pieces
{
    public class Checkers : BasePiece
    {
        protected override char Char => '♕';

        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            var boards = new List<BasePiece[,]>();
            var forwardRight = Location + new Vector(-1,  1);
            var forwardLeft =  Location + new Vector(-1, -1);
            var captureForRight = Location + new Vector(-2,  2);
            var captureForLeft =  Location + new Vector(-2, -2);
            var backwardRight = Location + new Vector(1, 1);
            var backwardLeft = Location + new Vector(1, -1);
            var captureBackRight = Location + new Vector(2, 2);
            var captureBackLeft = Location + new Vector(2, -2);

            //move
            if (IsOnBoard(forwardLeft)
                && board[forwardLeft.X, forwardLeft.Y] == null)
            {
                boards.Add(CloneBoardAndMove<Checkers>(board, forwardLeft));
            }

            if (IsOnBoard(forwardRight)
                && board[forwardRight.X, forwardRight.Y] == null)
            {
                boards.Add(CloneBoardAndMove<Checkers>(board, forwardRight));
            }

            if (IsOnBoard(backwardLeft)
                && board[backwardLeft.X, backwardLeft.Y] == null)
            {
                boards.Add(CloneBoardAndMove<Checkers>(board, backwardLeft));
            }

            if (IsOnBoard(backwardRight)
                && board[backwardRight.X, backwardRight.Y] == null)
            {
                boards.Add(CloneBoardAndMove<Checkers>(board, backwardRight));
            }

            //capture
            if (IsOnBoard(captureForLeft)
                && board[forwardLeft.X, forwardLeft.Y] != null
                && board[forwardLeft.X, forwardLeft.Y].Color != Color)
            {
                boards.Add(CloneBoardAndCapture<Checkers>(board, captureForLeft, forwardLeft));
            }
            
            if (IsOnBoard(captureForRight)
                && board[forwardRight.X, forwardRight.Y] != null
                && board[forwardRight.X, forwardRight.Y].Color != Color)
            {
                boards.Add(CloneBoardAndCapture<Checkers>(board, captureForRight, forwardRight));
            }

            if (IsOnBoard(captureBackLeft)
                && board[backwardLeft.X, backwardLeft.Y] != null
                && board[backwardLeft.X, backwardLeft.Y].Color != Color)
            {
                boards.Add(CloneBoardAndCapture<Checkers>(board, captureBackLeft, backwardLeft));
            }

            if (IsOnBoard(captureBackRight)
                && board[backwardRight.X, backwardRight.Y] != null
                && board[backwardRight.X, backwardRight.Y].Color != Color)
            {
                boards.Add(CloneBoardAndCapture<Checkers>(board, captureBackRight, backwardRight));
            }



            return boards.ToArray();
        }

        protected BasePiece[,] CloneBoardAndCapture<T>(BasePiece[,] board, Vector landingSpot, Vector capturedPiece)
            where T : BasePiece, new()
        {
            var newBoard = Clone(board);
            //remove from where it was
            newBoard[Location.X, Location.Y] = null;
            //remove captured piece
            newBoard[capturedPiece.X, capturedPiece.Y] = null;
            //put in new place
            newBoard[landingSpot.X, landingSpot.Y] =
                new T() { Color = Color, HasMoved = true, Location = landingSpot };
            return newBoard;
        }

    }
}
