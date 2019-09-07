using System.Collections.Generic;
using LearnChess.Application.Domain;
using LearnChess.Application.UnitTests.Helpers;
using NUnit.Framework;
using static LearnChess.Application.UnitTests.Helpers.ChessboardFieldState;

namespace LearnChess.Application.UnitTests.Domain.TestData
{
    internal class QueenMovesTestData
    {
        private const ChessPieceKind ChessPiece = ChessPieceKind.Queen;
        
        public static IEnumerable<TestCaseData> GetQueenMovesTestData()
        {
            yield return WithInitialChessboardState(new Chessboard 
                {
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, T, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _}
                })
                .Expect(new Chessboard
                {
                    {_, P, _, _, P, _, _, P},
                    {_, _, P, _, P, _, P, _},
                    {_, _, _, P, P, P, _, _},
                    {P, P, P, P, T, P, P, P},
                    {_, _, _, P, P, P, _, _},
                    {_, _, P, _, P, _, P, _},
                    {_, P, _, _, P, _, _, P},
                    {P, _, _, _, P, _, _, _}
                });
            
            yield return WithInitialChessboardState(new Chessboard 
                {
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, T}
                })
                .Expect(new Chessboard
                {
                    {P, _, _, _, _, _, _, P},
                    {_, P, _, _, _, _, _, P},
                    {_, _, P, _, _, _, _, P},
                    {_, _, _, P, _, _, _, P},
                    {_, _, _, _, P, _, _, P},
                    {_, _, _, _, _, P, _, P},
                    {_, _, _, _, _, _, P, P},
                    {P, P, P, P, P, P, P, T}
                });
        }

        private static IExpectedChessboardStateStep WithInitialChessboardState(Chessboard chessboard)
        {
            return PieceMoveTestDataBuilder.ForChessPiece(ChessPiece).WithInitialChessboardState(chessboard);
        }
    }
}