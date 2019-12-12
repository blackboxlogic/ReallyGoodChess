using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MarquisPlayer : BasePlayer
    {
		int turn = 1;
		Regex isnumber = new Regex("[0-9]+");


		override public int ChooseMove(BasePiece[][,] options)
		{
			
			int numChoices = options.Length;
			Console.WriteLine("This is turn number " + turn);
			Console.WriteLine("Please enter a number between 1 and " + numChoices);
			String c = Console.ReadLine();
			while(!isnumber.IsMatch(c))
			{
				Console.WriteLine("Invalid input. Please enter a number between 1 and " + numChoices);
				c = Console.ReadLine();
			}
			int choice = Int32.Parse(c)-1;
			while(choice < 0 || choice+1 > numChoices || !isnumber.IsMatch(c))
			{
				Console.WriteLine("Invalid number. Please enter a number between 1 and " + numChoices);
				c = Console.ReadLine();
				choice = Int32.Parse(c) - 1;
			}
			turn++;
			return choice;
		}
	}
}
