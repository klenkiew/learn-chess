using System.Collections.Generic;
using System.Linq;
using LearnChess.Application.Domain;
using LearnChess.Application.UnitTests.Domain.TestData;
using LearnChess.Application.UnitTests.Helpers;
using NUnit.Framework;

namespace LearnChess.Application.UnitTests.Domain
{
    internal class PieceMovesTest
    {
        [TestCaseSource(typeof(PieceMovesData), nameof(PieceMovesData.TestCases))]
        public ChessboardState TestPieceMoves(ChessPieceKind chessPieceKind, ChessboardState initialState)
        {
            var chessPiece = new ChessPieceFactory().CreateChessPiece(chessPieceKind);
            var currentPosition = initialState.GetCurrentPosition();
            return ChessboardState.CreateFromMoves(currentPosition, chessPiece.GetPossibleMoves(currentPosition));
        }
    }

    internal class PieceMovesData
    {
        public static IEnumerable<TestCaseData> TestCases()
        {
            return Concat(
                KnightMovesTestData.GetKnightMovesTestData(),
                QueenMovesTestData.GetQueenMovesTestData(),
                RookMovesTestData.GetRookMovesTestData());
        }

        private static IEnumerable<T> Concat<T>(params IEnumerable<T>[] lists)
        {
            return lists.SelectMany(e => e);
        }
    }
}