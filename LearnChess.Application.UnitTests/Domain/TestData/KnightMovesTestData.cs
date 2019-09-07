using System.Collections.Generic;
using LearnChess.Application.Domain;
using LearnChess.Application.UnitTests.Helpers;
using NUnit.Framework;
using static LearnChess.Application.UnitTests.Helpers.ChessboardFieldState;

namespace LearnChess.Application.UnitTests.Domain.TestData
{
    internal class KnightMovesTestData
    {
        private const ChessPieceKind ChessPiece = ChessPieceKind.Knight;
        
        public static IEnumerable<TestCaseData> GetKnightMovesTestData()
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
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, P, _, P, _, _},
                    {_, _, P, _, _, _, P, _},
                    {_, _, _, _, T, _, _, _},
                    {_, _, P, _, _, _, P, _},
                    {_, _, _, P, _, P, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _}
                });
            
            
            yield return WithInitialChessboardState(new Chessboard 
                {
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, T, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _}
                })
                .Expect(new Chessboard
                {
                    {_, _, _, _, P, _, _, _},
                    {_, _, _, _, _, _, T, _},
                    {_, _, _, _, P, _, _, _},
                    {_, _, _, _, _, P, _, P},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _}
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
                    {T, _, _, _, _, _, _, _}
                })
                .Expect(new Chessboard
                {
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, P, _, _, _, _, _, _},
                    {_, _, P, _, _, _, _, _},
                    {T, _, _, _, _, _, _, _}
                });
        }

        private static IExpectedChessboardStateStep WithInitialChessboardState(Chessboard chessboard)
        {
            return PieceMoveTestDataBuilder.ForChessPiece(ChessPiece).WithInitialChessboardState(chessboard);
        }
    }
}