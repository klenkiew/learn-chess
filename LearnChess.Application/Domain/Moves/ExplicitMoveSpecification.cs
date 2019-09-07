using System.Collections.Generic;
using System.Linq;

namespace LearnChess.Application.Domain.Moves
{
    internal abstract class ExplicitMoveSpecification : IChessMoveTypeSpecification
    {
        protected abstract IEnumerable<PositionChange> AllowedMoves { get; }

        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return AllowedMoves
                .Where(currentPosition.CanMoveBy)
                .Select(move => new ChessMove(currentPosition, currentPosition.MovedBy(move)));
        }
    }
}