using System.Collections.Generic;
using static LearnChess.Application.Domain.PositionChange;

namespace LearnChess.Application.Domain.Moves
{
    internal class BishopMoveSpecification : RepeatableMoveSpecification
    {
        private static readonly IEnumerable<PositionChange> bishopMoves = new[]
        {
            By(1, 1), By(-1, -1), By(-1, 1), By(1, -1)
        };

        protected override IEnumerable<PositionChange> AllowedMoves => bishopMoves;
    }
}