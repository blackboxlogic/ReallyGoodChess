using Model;
using Model.Pieces;
using System;
using System.Text;

namespace ChessConsoleApp
{
    class ChessConsoleApp
    {
        public static Game SetUp(String p1, String p2)
        {
			var board = new BasePiece[8, 8];
			board[0, 1] = new Knight() { Color = Color.White, Location = new Vector(0, 1) };
            board[0, 6] = new Knight() { Color = Color.White, Location = new Vector(0, 6) };
            board[7, 1] = new Knight() { Color = Color.Black, Location = new Vector(7, 1) };
			board[7, 6] = new Knight() { Color = Color.Black, Location = new Vector(7, 6) };

            board[0, 2] = new Bishop() {Color = Color.White, Location = new Vector(0, 2) };
            board[0, 5] = new Bishop() { Color = Color.White, Location = new Vector(0, 5) };
            board[7, 2] = new Bishop() { Color = Color.Black, Location = new Vector(7, 2) };
			board[7, 5] = new Bishop() { Color = Color.Black, Location = new Vector(7, 5) };

            board[0, 0] = new Rook() { Color = Color.White, Location = new Vector(0, 0) };
            board[0, 7] = new Rook() { Color = Color.White, Location = new Vector(0, 7) };
            board[7, 0] = new Rook() { Color = Color.Black, Location = new Vector(7, 0) };
			board[7, 7] = new Rook() { Color = Color.Black, Location = new Vector(7, 7) };

			board[0, 4] = new King() { Color = Color.White, Location = new Vector(0, 4) };
			board[0, 3] = new Scissors() { Color = Color.White, Location = new Vector(0, 3) };
			board[7, 4] = new King() { Color = Color.Black, Location = new Vector(7, 4) };
			board[7, 3] = new Scissors() { Color = Color.Black, Location = new Vector(7, 3) };

			for (int i = 0; i < 8; i++)
            {
				board[1, i] = new Pawn() { Color = Color.White, Location = new Vector(1, i) };
				board[6, i] = new Pawn() { Color = Color.Black, Location = new Vector(6, i) };
            }

			Game Game = new Game();
			Game.History.Push(board);
			Game.Players.Enqueue(new BasePlayer() { Name = p1, Color = Color.White });
			Game.Players.Enqueue(new BasePlayer() { Name = p2, Color = Color.Black });

			return Game;
        }

        static void Main(string[] args)
        {
			Console.OutputEncoding = Encoding.Unicode;
			double? result;
			Console.WriteLine("Player 1, enter your name:");
			var p1 = Console.ReadLine();
			Console.WriteLine("Player 2, enter your name:");
			var p2 = Console.ReadLine();
			result = simulateGame(p1,p2);
			while ((result = simulateGame(p1, p1)) == .5)
			{
				result = simulateGame(p1,p2);
			}


			
		}

		private static double? simulateGame(String p1, String p2)
		{
			Game game = SetUp(p1, p2);
			Console.WriteLine("Current board state:");
			game.CurrentBoard.ToConsole();
			double? result = null;

			while (result == null)
			{
				Console.WriteLine((game.Turn.ToString().Equals("White")) ? $"{p1}'s moves:" : $"{p2}'s moves:");

				var moves = game.GetMoves();
				int count = 0;
				foreach(var b in moves)
				{
					count++;
					Console.WriteLine($"Move #{count}");
					b.ToConsole(b);
				}
				Console.WriteLine("Total possible moves: " + moves.Length+"\n");

				Console.WriteLine((game.Turn.ToString().Equals("White")) ? $"{p1}, pick a move." : $"{p2}, pick a move.");

				Console.WriteLine("  ");
				var inputString = Console.ReadLine();
				if(Int32.TryParse(inputString, out int moveIndex)){
					if(moveIndex-1 < moves.Length)
					{
						Console.WriteLine("Move successful");
						game.TakeATurn(moveIndex-1);
					}
					else {
						Console.WriteLine($"No such move #{moveIndex}. Pick another");
					}
				}
				else
				{
					Console.WriteLine($"Int32.TryParse could not parse  '{inputString}' to an int");
				}

				Console.WriteLine("Current board state:");
				game.CurrentBoard.ToConsole(game.PreviousBoard());
				result = game.CheckWinner();
				//System.Threading.Thread.Sleep(50);
				//Console.ReadKey(true);
			}

			Console.WriteLine(result);
			Console.ReadKey(false);
			
			return result;
		}
	}
}
