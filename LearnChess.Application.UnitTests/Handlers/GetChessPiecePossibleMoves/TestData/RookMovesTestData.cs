using System.Collections.Generic;
using LearnChess.Application.Domain;
using LearnChess.Application.UnitTests.Handlers.GetChessPiecePossibleMoves.Helpers;
using LearnChess.Application.UnitTests.Helpers;
using NUnit.Framework;
using static LearnChess.Application.UnitTests.Helpers.ChessboardFieldState;

namespace LearnChess.Application.UnitTests.Handlers.GetChessPiecePossibleMoves.TestData
{
    internal class RookMovesTestData
    {
        private const ChessPieceKind ChessPiece = ChessPieceKind.Rook;
        
        public static IEnumerable<TestCaseData> GetRookMovesTestData()
        {
            yield return WithInitialChessboardState(new Chessboard 
                {
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, C, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _},
                    {_, _, _, _, _, _, _, _}
                })
                .Expect(new Chessboard
                {
                    {_, _, _, _, A, _, _, _},
                    {_, _, _, _, A, _, _, _},
                    {_, _, _, _, A, _, _, _},
                    {A, A, A, A, C, A, A, A},
                    {_, _, _, _, A, _, _, _},
                    {_, _, _, _, A, _, _, _},
                    {_, _, _, _, A, _, _, _},
                    {_, _, _, _, A, _, _, _}
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
                    {_, _, _, _, _, _, _, C}
                })
                .Expect(new Chessboard
                {
                    {_, _, _, _, _, _, _, A},
                    {_, _, _, _, _, _, _, A},
                    {_, _, _, _, _, _, _, A},
                    {_, _, _, _, _, _, _, A},
                    {_, _, _, _, _, _, _, A},
                    {_, _, _, _, _, _, _, A},
                    {_, _, _, _, _, _, _, A},
                    {A, A, A, A, A, A, A, C}
                });
        }

        private static IExpectedChessboardStateStep WithInitialChessboardState(Chessboard chessboard)
        {
            return PieceMoveTestDataBuilder.ForChessPiece(ChessPiece).WithInitialChessboardState(chessboard);
        }
    }
}