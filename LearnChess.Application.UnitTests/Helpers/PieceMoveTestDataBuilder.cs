using LearnChess.Application.Domain;
using NUnit.Framework;

namespace LearnChess.Application.UnitTests.Helpers
{
    internal interface IInitialChessboardStateStep
    {
        IExpectedChessboardStateStep WithInitialChessboardState(Chessboard chessboard);
    }
    
    internal interface IExpectedChessboardStateStep
    {
        TestCaseData Expect(Chessboard expectedChessboard);
    }
    
    internal class PieceMoveTestDataBuilder : IInitialChessboardStateStep, IExpectedChessboardStateStep
    {
        private readonly ChessPieceKind chessPiece;
        private Chessboard initialChessboardState;

        private PieceMoveTestDataBuilder(ChessPieceKind chessPiece)
        {
            this.chessPiece = chessPiece;
        }

        public static IInitialChessboardStateStep ForChessPiece(ChessPieceKind chessPiece)
        {
            return new PieceMoveTestDataBuilder(chessPiece);
        }

        IExpectedChessboardStateStep 
            IInitialChessboardStateStep.WithInitialChessboardState(Chessboard chessboard)
        {
            initialChessboardState = chessboard;
            return this;
        }

        TestCaseData IExpectedChessboardStateStep.Expect(Chessboard expectedChessboard)
        {
            return new TestCaseData(chessPiece, initialChessboardState.Build).Returns(expectedChessboard.Build);
        }
    }
}