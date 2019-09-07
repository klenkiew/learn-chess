using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers.ValidateChessPieceMove;
using LearnChess.Application.UnitTests.Handlers.ValidateChessPieceMove.TestData;
using LearnChess.Application.UnitTests.Helpers;
using MediatR;
using NUnit.Framework;

namespace LearnChess.Application.UnitTests.Handlers.ValidateChessPieceMove
{
    internal class ValidatePieceMoveTest
    {
        [TestCaseSource(typeof(ValidatePieceMoveTestData), nameof(ValidatePieceMoveTestData.TestCases))]
        public ValidateChessPieceMoveResponse TestPieceMoves(
            ChessPieceKind chessPieceKind, ChessboardState chessboardState)
        {
            var currentPosition = chessboardState.GetCurrentPosition();
            var targetPosition = chessboardState.GetTargetPosition();
            var request = new ValidateChessPieceMoveRequest(chessPieceKind, currentPosition, targetPosition);
            var result = HandleRequest(request);
            return result;
        }

        private static ValidateChessPieceMoveResponse HandleRequest(ValidateChessPieceMoveRequest request)
        {
            var handler = CreateHandler();
            return handler.Handle(request, CancellationToken.None).Result;
        }

        private static IRequestHandler<ValidateChessPieceMoveRequest, ValidateChessPieceMoveResponse> 
            CreateHandler()
        {
            var handler = new ValidateChessPieceMoveHandler(new ChessPieceCollection());
            return handler;
        }

    }

    internal class ValidatePieceMoveTestData
    {
        public static IEnumerable<TestCaseData> TestCases()
        {
            return Concat(
                KnightValidateMoveTestData.GetKnightMovesTestData(),
                QueenValidateMoveTestData.GetQueenMovesTestData(),
                RookValidateMoveTestData.GetRookMovesTestData());
        }

        private static IEnumerable<T> Concat<T>(params IEnumerable<T>[] collections)
        {
            return collections.SelectMany(e => e);
        }
    }
}