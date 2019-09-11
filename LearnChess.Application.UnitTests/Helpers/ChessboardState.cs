using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LearnChess.Application.Handlers;
using static LearnChess.Application.UnitTests.Helpers.ChessboardFieldState;

namespace LearnChess.Application.UnitTests.Helpers
{
    internal class ChessboardState
    {
        private readonly ChessboardFieldState[][] fields;

        public ChessboardState(ChessboardFieldState[][] chessboardFieldStates)
        {
            ValidateChessboard(chessboardFieldStates);
            fields = chessboardFieldStates;
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        private static void ValidateChessboard(ChessboardFieldState[][] chessboardFieldStates)
        {
            if (chessboardFieldStates.Length != 8)
                throw new Exception($"Chessboard column count should be 8, was {chessboardFieldStates.Length}");

            for (var columnIndex = 0; columnIndex < chessboardFieldStates.Length; columnIndex++)
            {
                if (chessboardFieldStates[columnIndex] == null || chessboardFieldStates[columnIndex].Length != 8)
                {
                    throw new Exception(
                        $"Chessboard row count should be 8, was {chessboardFieldStates.Length} for column {columnIndex}");
                }
            }
        }

        public ChessboardPositionDto GetCurrentPosition()
        {
            return FindChessboardPosition(chessboardFieldState: C);
        }
        
        public ChessboardPositionDto GetTargetPosition()
        {
            return FindChessboardPosition(chessboardFieldState: T);
        }

        private ChessboardPositionDto FindChessboardPosition(ChessboardFieldState chessboardFieldState)
        {
            for (var i = 0; i < fields.Length; i++)
            {
                for (var j = 0; j < fields[i].Length; j++)
                {
                    if (fields[i][j] == chessboardFieldState)
                        return new ChessboardPositionDto(j, i);
                }
            }
            throw new Exception($"No position with state {chessboardFieldState} on this chessboard");
        }
        
        public static ChessboardState CreateFromMoves(
            ChessboardPositionDto currentPosition, IEnumerable<ChessboardPositionDto> targetPositions)
        {
            var chessboard = new[]
            {
                new[] { _, _, _, _, _, _, _, _},
                new[] { _, _, _, _, _, _, _, _},
                new[] { _, _, _, _, _, _, _, _},
                new[] { _, _, _, _, _, _, _, _},
                new[] { _, _, _, _, _, _, _, _},
                new[] { _, _, _, _, _, _, _, _},
                new[] { _, _, _, _, _, _, _, _},
                new[] { _, _, _, _, _, _, _, _}
            };
            chessboard[currentPosition.Y][currentPosition.X] = C;
            
            foreach (var targetPosition in targetPositions) 
                chessboard[targetPosition.Y][targetPosition.X] = A;
            return new ChessboardState(chessboard);
        }
        
        public override string ToString()
        {
            var builder = new StringBuilder("\n");
            foreach (var row in fields)
            {
                foreach (var field in row) 
                    builder.Append(field).Append(" ");
                builder.Append("\n");
            }
            builder.Append("\n");
            return builder.ToString();
        }
        
        private bool Equals(ChessboardState other)
        {
            return ((IStructuralEquatable)fields).Equals(other.fields, StructuralComparisons.StructuralEqualityComparer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((ChessboardState) obj);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)fields).GetHashCode(StructuralComparisons.StructuralEqualityComparer);
        }
    }
    
    public enum ChessboardFieldState
    {
        _, // a free field
        C, // a currently taken field
        A, // allowed - the piece can be moved to this position
        T, // target position
    }
}