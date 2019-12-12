using System;
using System.Collections.Generic;
using Model;

namespace ChessConsoleApp {
    public class humanPlayer : BasePlayer {
        public override int ChooseMove(BasePiece[][,] options, BasePiece[,] currentBoard) {

            Console.WriteLine("Please Provide A Move By Typing In One Of The Following Option Numbers ");
            Console.WriteLine("Or Type help To Get Help ");

            //sleeps so users have time to read the message
            System.Threading.Thread.Sleep(1300);

            for (var i = 0; i < options.Length; i++) {
                Console.WriteLine("option " + i + ":");
                options[i].ToConsole(currentBoard);
            }

            return userInput(currentBoard);
        }

        public int userInput(BasePiece[,] currentBoard) {

            int inputAsInt;
            String input = Console.ReadLine();
            
           //checks to see if a command was given
           commands commandChecker = new commands();
           if (commandChecker.checkCommands(currentBoard, input)) {
               return userInput(currentBoard);
           }
            
            //error handling
            if (Int32.TryParse(input, out inputAsInt)) {
                return inputAsInt;
            }

            Console.WriteLine("Please Provide A Valid Option Number: ");
           
            return userInput(currentBoard);
        }
        
    }
}