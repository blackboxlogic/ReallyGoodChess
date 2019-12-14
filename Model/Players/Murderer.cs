using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Players
{
    public class Murderer : BasePlayer
    {
		override public int ChooseMove(BasePiece[][,] options)
		{
			int bestIndex = 0;
			double bestScore = ScoreMove(options[0]);

			for (int i = 1; i < options.Length; i++)
			{
				double score = ScoreMove(options[i]);
				if (score > bestScore)
				{
					bestIndex = i;
					bestScore = score;
				}
			}

			return bestIndex;
		}

		override protected double ScoreMove(BasePiece[,] options)
		{
			//Return the number of enemies missing plus the number of your guys alive
			int enemiesKilled = 16;
			int yourUnitsAlive = 0;
			foreach (BasePiece p in options) {
				if (p != null && p.Color != Color)
					enemiesKilled--;
				else if (p != null && p.Color == Color)
					yourUnitsAlive++;
			}
			return enemiesKilled + yourUnitsAlive;

		}
	}
}
