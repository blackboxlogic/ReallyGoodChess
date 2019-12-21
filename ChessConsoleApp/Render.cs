﻿using Model;
using System;

namespace ChessConsoleApp
{
	public static class Render
	{
		public static void ToConsole(this BasePiece[,] board, BasePiece[,] lastBoard = null)
		{
			for (int x = 0; x < 8; x++)
			{
				for (int y = 0; y < 8; y++)
				{
					Console.BackgroundColor = (x + y) % 2 == 1 ? ConsoleColor.DarkGray : ConsoleColor.Gray;

					if (lastBoard != null && lastBoard[x, y] != board[x, y])
					{
						Console.BackgroundColor = ConsoleColor.Cyan;
					}

					var piece = board[x, y];
					if (piece != null)
					{
						Console.ForegroundColor = piece.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
						
						if ((piece.GetType() == typeof(Model.Pieces.Jester)) && (piece.Color == Color.Black))
						{
							//Console.ForegroundColor = ConsoleColor.Black;
							Console.Write(piece.AsBaseChar());
						}
						else
						{
							Console.Write(piece.AsColoredChar());
						}
						
						Console.Write(" ");
					}
					else
					{
						Console.Write("  ");
					}
				}
				Console.WriteLine();
			}

			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
		}
	}
}
