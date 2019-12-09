using ChessConsoleApp;
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
        public void PawnCannotCaptureFriendlyPieces_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Pawn1 = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            var Pawn2 = new Pawn() { Color = Color.White, Location = new Vector(3, 3) };
            var Pawn3 = new Pawn() { Color = Color.White, Location = new Vector(2, 4) };
            board[1, 3] = Pawn1;
            board[3, 3] = Pawn2;
            board[2, 4] = Pawn3;
            var possibleMoves = Pawn1.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 1);
        }

        [Test]
        public void PawnCannotJumpOverFriendlyPieces_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Pawn1 = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            var Pawn2 = new Pawn() { Color = Color.White, Location = new Vector(2, 3) };
            board[1, 3] = Pawn1;
            board[2, 3] = Pawn2;
            var possibleMoves = Pawn1.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 0);
        }

        [Test]
        public void PawnCannotMoveSidewaysOrDiagonally_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Pawn1 = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            var Pawn2 = new Pawn() { Color = Color.White, Location = new Vector(2, 3) };
            var Pawn3 = new Pawn() { Color = Color.White, Location = new Vector(2, 4) };
            board[1, 3] = Pawn1;
            board[2, 3] = Pawn2;
            board[2, 4] = Pawn3;
            var possibleMoves = Pawn1.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 0);
        }

        [Test]
        public void PawnPerformsValidCapture_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Pawn1 = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            var Pawn2 = new Pawn() { Color = Color.White, Location = new Vector(2, 3) };
            var Pawn3 = new Pawn() { Color = Color.Black, Location = new Vector(2, 4) };
            board[1, 3] = Pawn1;
            board[2, 3] = Pawn2;
            board[2, 4] = Pawn3;
            var possibleMoves = Pawn1.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 1);
        }

        [Test]
        public void PawnCannotCaptureEnemyPieceInFrontOfIt_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Pawn1 = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            var Pawn2 = new Pawn() { Color = Color.Black, Location = new Vector(2, 3) };
            board[1, 3] = Pawn1;
            board[2, 3] = Pawn2;
            var possibleMoves = Pawn1.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 0);
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
        public void RookNumberOfMoves_RookCannotCaptureFriendlyPieces_FivePossibleMoves()
        {
            var board = new BasePiece[8, 8];
            var Rook = new Rook() { Color = Color.White, Location = new Vector(0, 0) };
            var Pawn= new Pawn() { Color = Color.White, Location = new Vector(2, 0) };
            var Bishop = new Bishop() { Color = Color.White, Location = new Vector(0, 5) };
            board[0, 0] = Rook;
            board[2, 0] = Pawn;
            board[0, 5] = Bishop;
            var possibleMoves = Rook.GetMoves(board).Length;
            Assert.AreEqual(5, possibleMoves);
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
        public void KnightCannotCaptureFriendlyPieces_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Knight = new Knight() { Color = Color.White, Location = new Vector(0, 1) };
            var Pawn1 = new Pawn() { Color = Color.White, Location = new Vector(2, 0) };
            var Pawn2 = new Pawn() { Color = Color.White, Location = new Vector(2, 2) };
            var Pawn3 = new Pawn() { Color = Color.White, Location = new Vector(1, 3) };
            board[0, 1] = Knight;
            board[2, 0] = Pawn1;
            board[2, 2] = Pawn2;
            board[1, 3] = Pawn3;
            var possibleMoves = Knight.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 0);
        }

        [Test]
        public void KnightCanJumpOverFriendlyPieces_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Knight = new Knight() { Color = Color.White, Location = new Vector(0, 1) };
            board[0, 1] = Knight;
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn() { Color = Color.White, Location = new Vector(1, i) };
            }
            var possibleMoves = Knight.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves > 0);
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
        public void BishopCannotCaptureFriendlyPieces_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Bishop = new Bishop() { Color = Color.White, Location = new Vector(0, 2) };
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn() { Color = Color.White, Location = new Vector(1, i) };
            }
            var possibleMoves = Bishop.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 0);
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
        public void SnowmanCanJumpOverFriendlyPieces_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Snowman = new Snowman() { Color = Color.White, Location = new Vector(0, 3) };
            board[0, 3] = Snowman;
            board[0, 0] = new Rook() { Color = Color.White, Location = new Vector(0, 0) };
            board[0, 7] = new Rook() { Color = Color.White, Location = new Vector(0, 7) };
            board[0, 1] = new Knight() { Color = Color.White, Location = new Vector(0, 1) };
            board[0, 6] = new Knight() { Color = Color.White, Location = new Vector(0, 6) };
            board[0, 2] = new Bishop() { Color = Color.White, Location = new Vector(0, 2) };
            board[0, 5] = new Bishop() { Color = Color.White, Location = new Vector(0, 5) };
            board[0, 4] = new King() { Color = Color.White, Location = new Vector(0, 4) };
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn() { Color = Color.White, Location = new Vector(1, i) };
            }
            var possibleMoves = Snowman.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves > 0);
        }

        [Test]
        public void SnowmanCanCaptureEnemyPieceInFrontOfIt_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Snowman = new Snowman() { Color = Color.White, Location = new Vector(0, 3) };
            var Pawn = new Pawn() { Color = Color.Black, Location = new Vector(2, 3) };
            board[0, 3] = Snowman;
            board[2, 3] = Pawn;
            var possibleMoves = Snowman.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 5);
        }

        [Test]
        public void SnowmanCannotCaptureFriendlyPieceInFrontOfIt_ReturnsTrue()
        {
            var board = new BasePiece[8, 8];
            var Snowman = new Snowman() { Color = Color.White, Location = new Vector(0, 3) };
            var Pawn = new Pawn() { Color = Color.White, Location = new Vector(2, 3) };
            board[0, 3] = Snowman;
            board[2, 3] = Pawn;
            var possibleMoves = Snowman.GetMoves(board).Length;
            Assert.IsTrue(possibleMoves == 4);
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

    }
}