using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BetterPlayer : BasePlayer
    {

        //iterates through all moves, makes a move if it results in a capture, else makes the first move in the options array
        public override int ChooseMove(BasePiece[][,] options)
        {
            int bestIndex = 0;
            for(int i = 0;  i < options.Length; i++)
            {
                if(PieceCaptured(options, options[i]))
                {
                    return i;
                }
            }
            return bestIndex;
        }

        //checks if there are fewer pieces on the board in this move than the first possible option
        virtual protected bool PieceCaptured(BasePiece[][,] options, BasePiece[,] move)
        {
            int firstMovePieces = 0;
            int currMovePieces = 0;
            foreach(BasePiece p in options[0])
            {
                if (p != null)
                {
                    firstMovePieces++;
                }
            }

            foreach(BasePiece p in move)
            {
                if(p != null)
                {
                    currMovePieces++;
                }
            }

            if(currMovePieces < firstMovePieces)
            {
                return true;
            }
            return false;
        }
    }
}
