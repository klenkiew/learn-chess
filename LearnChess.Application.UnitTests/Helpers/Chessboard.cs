using System.Collections;
using System.Collections.Generic;

namespace LearnChess.Application.UnitTests.Helpers
{
    internal class Chessboard : IEnumerable<ChessboardFieldState>
    {
        private readonly ChessboardFieldState[][] fields = new ChessboardFieldState[8][];
        private int currentIndex = 0;

        public ChessboardState Build => new ChessboardState(fields);

        // The internals of this solution are somewhat hacky but the tests are very expressive this way
        // so I guess it's okay.
        public void Add(
            ChessboardFieldState column1,
            ChessboardFieldState column2,
            ChessboardFieldState column3,
            ChessboardFieldState column4,
            ChessboardFieldState column5,
            ChessboardFieldState column6,
            ChessboardFieldState column7,
            ChessboardFieldState column8)
        {
            fields[currentIndex++] = new[]
            {
                column1,
                column2,
                column3,
                column4,
                column5,
                column6,
                column7,
                column8,
            };
        }

        // Need to implement the IEnumerable interface to use the collection initializer syntax
        public IEnumerator<ChessboardFieldState> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}