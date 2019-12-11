using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Pieces
{
    public class PieceyMcPiece : BasePiece
    {
        protected override char Char => '✩';

         //Act as a random piece each turn 
        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            Random r = new Random();
            Type[] types = new[] { typeof(Pawn), typeof(Knight), typeof(Bishop), typeof(Rook) };

            //Get a random piece
            var type = types[r.Next(0, types.Length)];

            var piece = (BasePiece)Activator.CreateInstance(type);
            piece.Location = Location;
            piece.Color = Color;
            piece.HasMoved = true;
           

            var moves = piece.GetMoves(board);
            var actualMoves = new List<BasePiece[,]>();

            
            for (int currMove = 0; currMove < moves.Length; currMove++)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (moves[currMove][x, y] != board[x, y])
                        {
                            actualMoves.Add(CloneBoardAndMove<PieceyMcPiece>(board, new Vector(x, y)));
                           //moves[currMove][x, y] = new PieceyMcPiece() { Color = Color, Location = new Vector(x, y) };
                        }

                    }
                }
            }
            return actualMoves.ToArray();
        }  
        
    }
}
