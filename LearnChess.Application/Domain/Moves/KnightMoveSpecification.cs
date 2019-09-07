using System.Collections.Generic;
using System.Linq;
using static LearnChess.Application.Domain.PositionChange;

namespace LearnChess.Application.Domain.Moves
{
    internal class KnightMoveSpecification : IChessMoveTypeSpecification
    {
        private static readonly IEnumerable<PositionChange> knightMoves = new[]
        {
            By(2, 1), By(2, -1), By(-2, 1), By(-2, -1),
            By(1, 2), By(1, -2), By(-1, 2), By(-1, -2),
        };
        
        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return knightMoves
                .Where(currentPosition.CanMoveBy)
                .Select(move => new ChessMove(currentPosition, currentPosition.MovedBy(move)));
        }
    }
}