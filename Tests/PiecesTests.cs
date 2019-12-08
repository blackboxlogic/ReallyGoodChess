using Model;
using Model.Pieces;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PawnNumberOfMoves_HasNotMovedYetOnEmptyBoard_TwoPossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var Pawn = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            board[1, 3] = Pawn;
            var possibleMoves = Pawn.GetMoves(board).Length;
            Assert.AreEqual(2, possibleMoves);        
        }

        [Test]
        public void RookNumberOfMoves_HasNotMovedYetOnEmptyBoard_FourteenPossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var Rook = new Rook() { Color = Color.White, Location = new Vector(0, 0) };
            board[0, 0] = Rook;
            var possibleMoves = Rook.GetMoves(board).Length;
            Assert.AreEqual(14, possibleMoves);
        }

        [Test]
        public void KnightNumberOfMoves_HasNotMovedYetOnEmptyBoard_ThreePossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var Knight = new Knight() { Color = Color.White, Location = new Vector(0, 1) };
            board[0, 1] = Knight;
            var possibleMoves = Knight.GetMoves(board).Length;
            Assert.AreEqual(3, possibleMoves);
        }

        [Test]
        public void BishopNumberOfMoves_HasNotMovedYetOnEmptyBoard_SevenPossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var Bishop = new Bishop() { Color = Color.White, Location = new Vector(0, 2) };
            board[0, 2] = Bishop;
            var possibleMoves = Bishop.GetMoves(board).Length;
            Assert.AreEqual(7, possibleMoves);
        }

        [Test]
        public void SnowmanNumberOfMoves_HasNotMovedYetOnEmptyBoard_ThreePossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var Snowman = new Snowman() { Color = Color.White, Location = new Vector(0, 3) };
            board[0, 3] = Snowman;
            var possibleMoves = Snowman.GetMoves(board).Length;
            Assert.AreEqual(5, possibleMoves);
        }

        [Test]
        public void KingNumberOfMoves_HasNotMovedYetOnEmptyBoard_FivePossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var King = new King() { Color = Color.White, Location = new Vector(0, 4) };
            board[0, 4] = King;
            var possibleMoves = King.GetMoves(board).Length;
            Assert.AreEqual(5, possibleMoves);
        }

        [Test]
        //Rook has 14 possible moves if it's located anywhere on an empty 8 X 8 chess board
        //TODO : Use loop to test for all given positions
        public void RookNumberOfMoves_AnywhereOnEmptyBoard_FourteenPossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var Rook = new Rook() { Color = Color.White, Location = new Vector(3, 4) };
            board[3, 4] = Rook;
            var possibleMoves = Rook.GetMoves(board).Length;
            Assert.AreEqual(14, possibleMoves);
        }
    }
}