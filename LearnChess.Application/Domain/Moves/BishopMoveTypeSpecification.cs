using System.Collections.Generic;
using System.Linq;
using static LearnChess.Application.Domain.PositionChange;

namespace LearnChess.Application.Domain.Moves
{
    internal class BishopMoveTypeSpecification : IChessMoveTypeSpecification
    {
        private static readonly IEnumerable<PositionChange> bishopMoves = new[]
        {
            By(1, 1), By(-1, -1), By(-1, 1), By(1, -1)
        };

        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return bishopMoves.SelectMany(move => MoveWhileValid(currentPosition, move));
        }

        private static IEnumerable<ChessMove> MoveWhileValid(
            ChessboardPosition currentPosition, PositionChange positionChange)
        {
            var initialPosition = currentPosition;
            var chessMoves = new List<ChessMove>();
            while (currentPosition.CanMoveBy(positionChange))
            {
                var nextPosition = currentPosition.MovedBy(positionChange);
                chessMoves.Add(new ChessMove(initialPosition, nextPosition));
                currentPosition = nextPosition;
            }
            return chessMoves;
        }
    }
}