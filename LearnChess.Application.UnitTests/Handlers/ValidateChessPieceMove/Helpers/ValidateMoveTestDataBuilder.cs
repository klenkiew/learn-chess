using LearnChess.Application.Domain;
using LearnChess.Application.Handlers.ValidateChessPieceMove;
using LearnChess.Application.UnitTests.Helpers;
using NUnit.Framework;

namespace LearnChess.Application.UnitTests.Handlers.ValidateChessPieceMove.Helpers
{
    internal interface IValidatedMoveStep
    {
        IExpectedResultStep MoveTo(Chessboard chessboard);
    }
    
    internal interface IExpectedResultStep
    {
        TestCaseData ShouldBeValid();
        TestCaseData ShouldBeInvalid();
    }
    
    internal class ValidateMoveTestDataBuilder : IValidatedMoveStep, IExpectedResultStep
    {
        private readonly ChessPieceKind chessPiece;
        private Chessboard initialChessboardState;

        private ValidateMoveTestDataBuilder(ChessPieceKind chessPiece)
        {
            this.chessPiece = chessPiece;
        }

        public static IValidatedMoveStep ForChessPiece(ChessPieceKind chessPiece)
        {
            return new ValidateMoveTestDataBuilder(chessPiece);
        }

        IExpectedResultStep IValidatedMoveStep.MoveTo(Chessboard chessboard)
        {
            initialChessboardState = chessboard;
            return this;
        }

        TestCaseData IExpectedResultStep.ShouldBeValid()
        {
            return new TestCaseData(chessPiece, initialChessboardState.Build)
                .Returns(ValidateChessPieceMoveResponse.ValidMove);
        }
        
        TestCaseData IExpectedResultStep.ShouldBeInvalid()
        {
            return new TestCaseData(chessPiece, initialChessboardState.Build)
                .Returns(ValidateChessPieceMoveResponse.InvalidMove);
        }
    }
}