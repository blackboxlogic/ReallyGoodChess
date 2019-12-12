using System;
using System.Collections.Generic;
using Model;

namespace ChessConsoleApp {
    public class humanPlayer : BasePlayer {
        
        public int ChooseMove(BasePiece[][,] options, BasePiece[,] currentBoard) {

           for (var i = 0; i < options.Length; i++ ) {
               Console.WriteLine("options: ");
               options[i].ToConsole(currentBoard);
           }
           
           
           string playerInput = Console.ReadLine();
           
           int playerMove;
           Int32.TryParse(playerInput, out playerMove);

           return playerMove;
        }
        
    }
}