using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnChess.Application.Domain;
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

        public ChessboardPosition GetCurrentPosition()
        {
            for (var i = 0; i < fields.Length; i++)
            {
                for (var j = 0; j < fields[i].Length; j++)
                {
                    if (fields[i][j] == T)
                        return new ChessboardPosition(j + 1, i + 1);
                }
            }
            throw new Exception("No current position on this chessboard");
        }

        public static ChessboardState CreateFromMoves(ChessboardPosition currentPosition, IEnumerable<ChessMove> moves)
        {
            if (moves.Any(m => !Equals(m.From, currentPosition)))
                throw new Exception("Invalid move from current position");
                
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
            chessboard[currentPosition.Y - 1][currentPosition.X - 1] = T;
            
            foreach (var chessMove in moves) 
                chessboard[chessMove.To.Y - 1][chessMove.To.X - 1] = P;
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
        T, // a currently taken field
        P // possible - the piece can be moved to this position
    }
}