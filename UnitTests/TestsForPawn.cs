using Model;
using Model.Pieces;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests
{
	[TestFixture]
	public class PawnTest
	{
		BasePiece[,] board = new BasePiece[8, 8];

		[SetUp]
		protected void Setup()
		{

			board[1, 4] = new Pawn() { Color = Color.White, HasMoved = true, Location = new Vector(1, 4) };
			board[6, 3] = new Pawn() { Color = Color.Black, HasMoved = true, Location = new Vector(6, 3) };

		}

		[Test]
		public void TestGetMoves()
		{
			List<BasePiece[,]> options = new List<BasePiece[,]>();

			foreach (var piece in board)
			{
				options.AddRange(piece.GetMoves(board));
			}

			int i = 1;
			//Figure out what options should be there

			Assert.IsTrue(options.Count == 2);
		}
	}
}