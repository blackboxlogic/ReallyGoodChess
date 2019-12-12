using System;
using System.Collections.Generic;

namespace Model.Pieces
{
    public class Marquis : BasePiece
    {

        private static Vector[] move1 = new Vector[] {
            new Vector(1, 1),
            new Vector(2, 3),
            new Vector(4, 5),
            new Vector(6, 7)
        };

        private static Vector[] move2 = new Vector[] {
            new Vector(-1, -1),
            new Vector(-2, -3),
            new Vector(-4, -5),
            new Vector(-6, -7)
        };

        private static Vector[] move3 = new Vector[]
            {
            new Vector(1, -1),
            new Vector(3, 2),
            new Vector(5, 4),
            new Vector(7, 6)
            };

        private static Vector[] move4 = new Vector[]
        {
            new Vector(-1, 1),
            new Vector(-3, -2),
            new Vector(-5, -4),
            new Vector(-7, -6)
        };

        protected override char Char => 'ℳ';

        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            //New list to store potential moves
            var boards = new List<BasePiece[,]>();

            foreach (var directions in new[] { move1, move2, move3, move4 })
            {
                foreach (var direction in directions)
                {
                    var landed = Location + direction;
                    if (IsOnBoard(landed))
                    {
                        if (board[landed.X, landed.Y] == null)
                        {
                            boards.Add(CloneBoardAndMove<Marquis>(board, landed));
                        }
                        //if there's a piece to capture add the move then break
                        else if (board[landed.X, landed.Y].Color != Color)
                        {
                            boards.Add(CloneBoardAndMove<Marquis>(board, landed));
                            break;
                        }
                        //if we get here it there is a piece of the same color so no more moves get added
                        else break;
                    }
                    else break;
                }
            }
            return boards.ToArray();

        }
    }
}
