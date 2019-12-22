using Model;
using Model.Pieces;
using System;
using System.Text;

namespace TestConsoleApp
{
	class TestConsole
	{
		public static Game SetUp()
		{
			var board = new BasePiece[8, 8];
			//			board[6, 4] = new Pawn() { Color = Color.White, HasMoved = true, Location = new Vector(6, 4) };
			//			board[1, 3] = new Pawn() { Color = Color.Black, HasMoved = true, Location = new Vector(1, 3) };
			for (int i = 0; i < 8; i++)
			{
				board[1, i] = new Pawn() { Color = Color.White, Location = new Vector(1, i) };
				board[6, i] = new Pawn() { Color = Color.Black, Location = new Vector(6, i) };
			}

			Game Game = new Game();
			Game.History.Push(board);
			Game.Players.Enqueue(new BasePlayer() { Name = "player1", Color = Color.White });
			Game.Players.Enqueue(new BasePlayer() { Name = "player2", Color = Color.Black });

			return Game;
		}

		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.Unicode;
			Game game = SetUp();
			game.CurrentBoard.ToConsole();
			double? result = null;

			while (result == null)
			{
				game.TakeATurn();
				game.CurrentBoard.ToConsole(game.PreviousBoard());
				result = game.ChechWinner();
				//System.Threading.Thread.Sleep(50);
				//Console.ReadKey(true);
			}

			Console.WriteLine(result);
			Console.ReadKey(false);
			return;
		}
	}
}
