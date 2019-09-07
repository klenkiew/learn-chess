using System.Collections.Generic;
using LearnChess.Application.Domain;
using LearnChess.Application.UnitTests.Handlers.ValidateChessPieceMove.Helpers;
using LearnChess.Application.UnitTests.Helpers;
using NUnit.Framework;
using static LearnChess.Application.UnitTests.Helpers.ChessboardFieldState;

namespace LearnChess.Application.UnitTests.Handlers.ValidateChessPieceMove.TestData
{
    internal class QueenValidateMoveTestData
    {
        private const ChessPieceKind ChessPiece = ChessPieceKind.Queen;
        
        public static IEnumerable<TestCaseData> GetQueenMovesTestData()
        {
            yield return MoveTo(new Chessboard
                {
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, C, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, T, _, _, _}
                })
                .ShouldBeValid();
            
            yield return MoveTo(new Chessboard
                {
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, C, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, T, _}
                })
                .ShouldBeInvalid();
        }

        private static IExpectedResultStep MoveTo(Chessboard chessboard)
        {
            return ValidateMoveTestDataBuilder.ForChessPiece(ChessPiece).MoveTo(chessboard);
        }
    }
}