using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Pieces
{
    public class Snowman : BasePiece
    {
        protected override char Char => '☃'; 

        private static Vector[] Directions = new Vector[] {
            new Vector(1, 1),
            new Vector(0, 2),
            new Vector(-1, 1),
            new Vector(2, 0),
            new Vector(1, -1),
            new Vector(-2, 0),
            new Vector(-1, -1),
            new Vector(0, -2)
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
                    && board[landed.X, landed.Y]?.Color != Color)
                {
                    boards.Add(CloneBoardAndMove<Snowman>(board, landed));
                }
            }

            return boards.ToArray();
        }
    }
}
