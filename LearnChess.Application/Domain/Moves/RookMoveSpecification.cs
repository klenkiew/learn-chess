using System.Collections.Generic;
using System.Linq;
using static LearnChess.Application.Domain.PositionChange;

namespace LearnChess.Application.Domain.Moves
{
    internal class RookMoveSpecification : IChessMoveTypeSpecification
    {
        private static readonly IEnumerable<PositionChange> rookMoves = new[]
        {
            By(0, 1), By(0, -1), By(1, 0), By(-1, 0)
        };

        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return rookMoves.SelectMany(move => MoveWhileValid(currentPosition, move));
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