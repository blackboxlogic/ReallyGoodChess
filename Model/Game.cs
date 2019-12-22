using Model.Players;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Model
{
	public class Game
	{
		public Stack<BasePiece[,]> History = new Stack<BasePiece[,]>();
		public Queue Players = new Queue();
		public Object CurrentPlayer;
		public BasePiece[,] CurrentBoard => History.Peek();
		public BasePiece[,] PreviousBoard()
		{
			if (History.Count < 2) return null;
			var current = History.Pop();
			var previous = History.Peek();
			History.Push(current);
			return previous;
		}

		public void TakeATurn()
		{
			GetNextPlayer();
			var moves = GetMoves();

			if (CurrentPlayer.GetType() == typeof(BasePlayer))
			{
				BasePlayer player1 = (BasePlayer)CurrentPlayer;
				int moveIndex = player1.ChooseMove(moves);
				History.Push(moves[moveIndex]);

			}
			else
			{
				HumanPlayer player2 = (HumanPlayer)CurrentPlayer;
				int moveIndex = player2.ChooseHumanMove(CurrentBoard,moves, player2);
				History.Push(moves[moveIndex]);
			}
		}
		public Color Turn()
		{
			if (CurrentPlayer.GetType() == typeof(BasePlayer))
			{
				BasePlayer player1 = (BasePlayer)CurrentPlayer;
				return player1.Color;
			}
			else
			{
				Players.HumanPlayer player2 = (Players.HumanPlayer)CurrentPlayer;
				return player2.Color;
			}
		}
		private void GetNextPlayer()
		{
			CurrentPlayer = Players.Dequeue(); ;
			Players.Enqueue(CurrentPlayer);
		}

		private BasePiece[][,] GetMoves()
		{
			List<BasePiece[,]> options = new List<BasePiece[,]>();
			var currentBoard = History.Peek();

			foreach (var piece in currentBoard)
			{
				if (piece?.Color == Turn())
				{
					options.AddRange(piece.GetMoves(currentBoard));
				}
			}

			return options.ToArray();
		}
		// null means game isn't over.
		// 0 is black win, 1 is white win, .5 is draw
		public double? ChechWinner()
		{
			if (History.Count > 2000) return .5;

			foreach (BasePiece p in CurrentBoard)
			{
				if (p?.Color == Turn()) return null;
			}

			return (int)Turn();
		}
	}
}
