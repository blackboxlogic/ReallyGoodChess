using Model;
using Model.Pieces;
using ChessConsoleApp;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Pawn_CantMoveTrappedByFriendlyPieces()
        {
            var board = new BasePiece[8, 8];
            var Pawn = new Pawn() { Color = Color.White, Location = new Vector(0, 1) };
            board[1, 0] = new Pawn() { Color = Color.White, Location = new Vector(0, 2) };
            board[1, 1] = new Pawn() { Color = Color.White, Location = new Vector(0, 2) };
            board[1, 2] = new Pawn() { Color = Color.White, Location = new Vector(0, 2) };

            var moveCount = Pawn.GetMoves(board).Length;
            Assert.AreEqual(0, moveCount);
        }

        [Test]
        public void Pawn_NumberOfMovesOnEmptyBoard()
        {
            var board = new BasePiece[8, 8];
            var Pawn = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            var moveCount = Pawn.GetMoves(board).Length;
            Assert.AreEqual(2, moveCount);
        }

        [Test]
        public void Bishop_CantMoveTrappedByFriendlyPieces()
        {
            var board = new BasePiece[8, 8];
            var Bishop = new Bishop() { Color = Color.White, Location = new Vector(0, 1) };
            board[1, 0] = new Pawn() { Color = Color.White, Location = new Vector(1, 0) };
            board[1, 2] = new Pawn() { Color = Color.White, Location = new Vector(1, 2) };

            var moveCount = Bishop.GetMoves(board).Length;
            Assert.AreEqual(0, moveCount);
        }

        [Test]
        public void Bishop_NumberOfMovesOnEmptyBoard()
        {
            var board = new BasePiece[8, 8];
            var Bishop = new Bishop() { Color = Color.White, Location = new Vector(0, 2) };
            var moveCount = Bishop.GetMoves(board).Length;
            Assert.AreEqual(7, moveCount);
        }

        [Test]
        public void King_CantMoveTrappedByFriendlyPieces()
        {
            var board = new BasePiece[8, 8];
            var King = new King() { Color = Color.White, Location = new Vector(0, 4) };

            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn() { Color = Color.White, Location = new Vector(1, i) };
            }

            board[0, 3] = new Pawn() { Color = Color.White, Location = new Vector(0, 3) };
            board[0, 5] = new Pawn() { Color = Color.White, Location = new Vector(0, 5) };


            var moveCount = King.GetMoves(board).Length;
            Assert.AreEqual(0, moveCount);
        }

        [Test]
        public void King_NumberOfMovesOnEmptyBoard()
        {
            var board = new BasePiece[8, 8];
            var King = new King() { Color = Color.White, Location = new Vector(0, 4) };
            var moveCount = King.GetMoves(board).Length;
            Assert.AreEqual(5, moveCount);
        }

        [Test]
        public void Knight_CantMoveTrappedByFriendlyPieces()
        {
            var board = new BasePiece[8, 8];
            var Knight = new Knight() { Color = Color.White, Location = new Vector(0, 1) };


            board[2, 0] = new Pawn() { Color = Color.White, Location = new Vector(2, 0) };
            board[2, 2] = new Pawn() { Color = Color.White, Location = new Vector(2, 2) };
            board[1, 3] = new Pawn() { Color = Color.White, Location = new Vector(1, 4) };

            var moveCount = Knight.GetMoves(board).Length;
            Assert.AreEqual(0, moveCount);
        }

        [Test]
        public void Knight_NumberOfMovesOnEmptyBoard()
        {
            var board = new BasePiece[8, 8];
            var Knight = new Knight() { Color = Color.White, Location = new Vector(0, 1) };
            var moveCount = Knight.GetMoves(board).Length;
            Assert.AreEqual(3, moveCount);
        }

        [Test]
        public void Star_CantMoveTrappedByFriendlyPieces()
        {
            var board = new BasePiece[8, 8];
            var Star = new Star() { Color = Color.White, Location = new Vector(0, 3) };


            board[2, 1] = new Pawn() { Color = Color.White, Location = new Vector(2, 1) };
            board[2, 5] = new Pawn() { Color = Color.White, Location = new Vector(2, 5) };

            var moveCount = Star.GetMoves(board).Length;
            Assert.AreEqual(0, moveCount);
        }

        [Test]
        public void Star_NumberOfMovesOnEmptyBoard()
        {
            var board = new BasePiece[8, 8];
            var Star = new Star() { Color = Color.White, Location = new Vector(0, 3) };
            var moveCount = Star.GetMoves(board).Length;
            Assert.AreEqual(2, moveCount);
        }

        [Test]
        public void Rook_CantMoveTrappedByFriendlyPieces()
        {
            var board = new BasePiece[8, 8];
            var Rook = new Rook() { Color = Color.White, Location = new Vector(0, 0) };

            board[1, 0] = new Pawn() { Color = Color.White, Location = new Vector(2, 1) };
            board[0, 1] = new Pawn() { Color = Color.White, Location = new Vector(2, 5) };

            var moveCount = Rook.GetMoves(board).Length;
            Assert.AreEqual(0, moveCount);
        }

        [Test]
        public void Rook_NumberOfMovesOnEmptyBoard()
        {
            var board = new BasePiece[8, 8];
            var Rook = new Rook() { Color = Color.White, Location = new Vector(0, 0) };
            var moveCount = Rook.GetMoves(board).Length;
            Assert.AreEqual(14, moveCount);
        }
    }
}