using System;

namespace Model.Players
{
	public class HumanPlayer : BasePlayer
	{
		public int ChooseHumanMove(BasePiece[,] currentBoard, BasePiece[][,] choices, HumanPlayer player)
		{
			int moveCount = 1;
			int moveIndex = 0;

			Console.WriteLine("Please enter the number of the move that you want to take:\n");

			for (int i = 0; i < choices.Length; i++)
			{
				foreach (var piece in choices[i])
				{
					if ((piece != null) && (piece.Color == player.Color)) 
					{
						if ((currentBoard[piece.Location.X, piece.Location.Y] == null) 
							|| (currentBoard[piece.Location.X, piece.Location.Y].Color != piece.Color)
							|| (currentBoard[piece.Location.X, piece.Location.Y].GetType() != piece.GetType()))
						{
							string shortType = (piece.GetType().ToString()).Replace("Model.Pieces.", "");
							Console.WriteLine($"{moveCount++}:\t{piece.Color} {shortType} to ({piece.Location.X},{piece.Location.Y})");

						}
					}
				}
			}

			moveIndex = Convert.ToInt32(Console.ReadLine());
			while (moveIndex  > moveCount)
			{
				Console.WriteLine("Not a vlid move number. Please try again");
				moveIndex = Convert.ToInt32(Console.ReadLine());
			}

			return moveIndex - 1;
		}
	}
}