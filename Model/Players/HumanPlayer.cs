using System;
using System.Text.RegularExpressions;

namespace Model.Players
{
    public class HumanPlayer : BasePlayer
    {
        override public int ChooseMove(BasePiece[][,] options)
        {
            int topValue = options.Length;
            Regex regex = new Regex(@"[0-9]+");

            Console.WriteLine("Choose a number from 1-" + topValue + ":");
            var userInput = Console.ReadLine();
            
            while (!regex.IsMatch(userInput))
            {
                Console.WriteLine("Not a number. Try Again.");
                userInput = Console.ReadLine();
            }

            var choice = Int32.Parse(userInput);

            while (choice < 1 || choice > topValue)
            {
                Console.WriteLine("Invalid choice. Try Again.");
                choice = Int32.Parse(Console.ReadLine());
            }

            return choice-1;
        }
    }
}
