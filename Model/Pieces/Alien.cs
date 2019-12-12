using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Pieces
{
    //The Alien can move like the rook, but only 3 spaces and it can jump pieces of the same color

    public class Alien : BasePiece
    {
        protected override char Char => '☊';

        private static Vector[] DirectionsForward = new Vector[] {
            new Vector(0, 1),
            new Vector(0, 2),
            new Vector(0, 3),
        };

        private static Vector[] DirectionsBack = new Vector[] {
            new Vector(0, -1),
            new Vector(0, -2),
            new Vector(0, -3),
        };

        private static Vector[] DirectionsRight = new Vector[]
            {
            new Vector(1, 0),
            new Vector(2, 0),
            new Vector(3, 0),
            };

        private static Vector[] DirectionsLeft = new Vector[]
        {
            new Vector(-1, 0),
            new Vector(-2, 0),
            new Vector(-3, 0),
        };

        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            //New list to store potential moves
            var boards = new List<BasePiece[,]>();

            foreach (var directions in new[] { DirectionsForward, DirectionsBack, DirectionsLeft, DirectionsRight })
            {
                foreach (var direction in directions)
                {
                    var landed = Location + direction;
                    if (IsOnBoard(landed))
                    {
                        if (board[landed.X, landed.Y] == null)
                        {
                            boards.Add(CloneBoardAndMove<Alien>(board, landed));
                        }
                        //if there's a piece to capture add the move then break
                        else if (board[landed.X, landed.Y].Color != Color)
                        {
                            boards.Add(CloneBoardAndMove<Alien>(board, landed));
                            break;
                        }
                    }
                    else break;
                }
            }
            return boards.ToArray();

        }
    }
}
