using System.Collections.Generic;
using static LearnChess.Application.Domain.PositionChange;

namespace LearnChess.Application.Domain.Moves
{
    internal class KnightMoveSpecification : ExplicitMoveSpecification
    {
        private static readonly IEnumerable<PositionChange> knightMoves = new[]
        {
            By(2, 1), By(2, -1), By(-2, 1), By(-2, -1),
            By(1, 2), By(1, -2), By(-1, 2), By(-1, -2),
        };

        protected override IEnumerable<PositionChange> AllowedMoves => knightMoves;
    }
}