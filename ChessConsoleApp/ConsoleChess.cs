using Model;
using Model.Pieces;
using System;
using System.Text;

namespace ChessConsoleApp
{
    class ChessConsoleApp
    {
	    
	    //checks the start commands given in the game
	    //and runs the create player command
	    public static commands comandRunner = new commands();
	    
		    public static Game SetUp()
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
			
			board[7, 4] = new King() { Color = Color.Black, Location = new Vector(7, 4) };
			
			board[0, 3] = new Squart() { Color = Color.White, Location = new Vector(0, 3) };
			board[7, 3] = new Squart() { Color = Color.Black, Location = new Vector(7, 3) };

			for (int i = 0; i < 8; i++)
            {
				board[1, i] = new Pawn() { Color = Color.White, Location = new Vector(1, i) };
				board[6, i] = new Pawn() { Color = Color.Black, Location = new Vector(6, i) };
            }

			Game Game = new Game();
			Game.History.Push(board);
			
			//makes the players
			comandRunner.createPlayers(Game);

			return Game;
        }

        static void Main(string[] args)
        {
	        
	        Console.WriteLine("Welcome to Really Good Chess!!");
	        Console.WriteLine("Type help To Get Help or Type Anything You Want To Start the Game");

	        string command = Console.ReadLine();
	       
	        //checks to see if a command was given
	        comandRunner.startCommands(command);

	        Console.WriteLine("Please Provide What Color You Would Like To Control: ");

	        
	        
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
