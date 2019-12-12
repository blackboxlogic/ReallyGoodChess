using System;
using System.Collections.Generic;

namespace Model {
    public class humanPlayer {
        
        public int chooseMove(BasePiece[][,] options) {

           foreach (var option in options) {
                Console.WriteLine(option);
            }
           
           
            
           string playerInput = Console.ReadLine();
           
           int playerMove;
           Int32.TryParse(playerInput, out playerMove);

           return playerMove;
        }
        
    }
}