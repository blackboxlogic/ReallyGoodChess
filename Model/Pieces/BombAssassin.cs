using System;
using System.Collections.Generic;
//BombAssassin 
//  cannot capture pieces or move like a normal piece
//  can only move by killing a friendly unit and stealing its location
//  can self destruct killing all units around it (including itself and teammates)
namespace Model.Pieces
{
    public class BombAssassin : BasePiece
    {
        protected override char Char => '☠';
        private readonly Vector[] Surroundings = {
            new Vector(-1, -1),
            new Vector(-1, 0),
            new Vector(-1, 1),
            new Vector(0, -1),
            new Vector(0, 1),
            new Vector(1, 1),
            new Vector(1, 0),
            new Vector(1, -1),
            new Vector(0, 0) //The piece sacrifices itself for the greater good
        };

        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            var boards = new List<BasePiece[,]>();

            var explodeBoard = Clone(board);
            foreach (Vector v in Surroundings)
            {
                var looking = Location + v;
                if (IsOnBoard(looking))
                    explodeBoard[looking.X, looking.Y] = null;
            }

            foreach (BasePiece p in board)
            {
                if (p?.Color == Color)
                {
                    boards.Add(CloneBoardAndMove<BombAssassin>(board, p.Location));
                }
            }

            boards.Add(explodeBoard);
            return boards.ToArray();
        }
    }
}
