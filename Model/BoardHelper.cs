using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class BoardHelper
    {
        public static IEnumerable<BasePiece> GetPieces(this BasePiece[,] board)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    var piece = board[x, y];
                    if (piece != null)
                    {
                        yield return piece;
                    }
                }
            }
        }
    }

}
