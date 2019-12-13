using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Model.Pieces;

namespace Model
{
    public class SemiIntelligentPlayer : BasePlayer
    {
        Random r = new Random();

        override public int ChooseMove(BasePiece[][,] options)
        {
            var bestMoveIndex = r.Next(0, options.Length);
            var bestMove = ScoreMove(options[bestMoveIndex]);
           
            var current = 0.0;
            for (int i = 0; i < options.Length; i++)
            {
                if ((current = ScoreMove(options[i])) > bestMove)
                {
                    bestMove = current;
                    bestMoveIndex = i;
                }
            }

            return bestMoveIndex;
        }

         override protected double ScoreMove(BasePiece[,] option)
        {
            return -(5 * option.GetPieces().Count(p => p.GetType() == typeof(King) ||
                                                  p.GetType() == typeof(PieceyMcPiece) && p.Color != Color) +
                     3 * option.GetPieces().Count(p => p.GetType() == typeof(Bishop) ||
                                                        p.GetType() == typeof(Rook) ||
                                                       p.GetType() == typeof(Knight) && p.Color != Color) +
                     option.GetPieces().Count(p => p.GetType() == typeof(Pawn) && p.Color != Color)
                );
        }

    }
}
