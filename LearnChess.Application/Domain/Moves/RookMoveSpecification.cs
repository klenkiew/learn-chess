using System.Collections.Generic;
using static LearnChess.Application.Domain.PositionChange;

namespace LearnChess.Application.Domain.Moves
{
    internal class RookMoveSpecification : RepeatableMoveSpecification
    {
        private static readonly IEnumerable<PositionChange> rookMoves = new[]
        {
            By(0, 1), By(0, -1), By(1, 0), By(-1, 0)
        };

        protected override IEnumerable<PositionChange> AllowedMoves => rookMoves;
    }
}