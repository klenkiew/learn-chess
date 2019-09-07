using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LearnChess.Application.Domain;
using LearnChess.Application.Handlers.GetChessPiecePossibleMoves;
using LearnChess.Application.UnitTests.Handlers.GetChessPiecePossibleMoves.TestData;
using LearnChess.Application.UnitTests.Helpers;
using MediatR;
using NUnit.Framework;

namespace LearnChess.Application.UnitTests.Handlers.GetChessPiecePossibleMoves
{
    internal class PieceAvailableMovesTest
    {
        [TestCaseSource(typeof(PieceAvailableMovesData), nameof(PieceAvailableMovesData.TestCases))]
        public ChessboardState TestPieceMoveValidation(ChessPieceKind chessPieceKind, ChessboardState initialState)
        {
            var currentPosition = initialState.GetCurrentPosition();
            var request = new GetChessPiecePossibleMovesRequest(currentPosition, chessPieceKind);
            var result = HandleRequest(request);
            Assert.That(result.CurrentPosition, Is.EqualTo(currentPosition));
            return ChessboardState.CreateFromMoves(result.CurrentPosition, result.PossibleMoves);
        }

        private static GetChessPiecePossibleMovesResponse HandleRequest(GetChessPiecePossibleMovesRequest request)
        {
            var handler = CreateHandler();
            return handler.Handle(request, CancellationToken.None).Result;
        }

        private static IRequestHandler<GetChessPiecePossibleMovesRequest, GetChessPiecePossibleMovesResponse> 
            CreateHandler()
        {
            var handler = new GetChessPiecePossibleMovesRequestHandler(new ChessPieceCollection());
            return handler;
        }
    }

    internal class PieceAvailableMovesData
    {
        public static IEnumerable<TestCaseData> TestCases()
        {
            return Concat(
                KnightMovesTestData.GetKnightMovesTestData(),
                QueenMovesTestData.GetQueenMovesTestData(),
                RookMovesTestData.GetRookMovesTestData());
        }

        private static IEnumerable<T> Concat<T>(params IEnumerable<T>[] collections)
        {
            return collections.SelectMany(e => e);
        }
    }
}