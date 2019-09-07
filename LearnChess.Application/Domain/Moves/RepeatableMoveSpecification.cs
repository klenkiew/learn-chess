using System.Collections.Generic;
using System.Linq;

namespace LearnChess.Application.Domain.Moves
{
    internal abstract class RepeatableMoveSpecification : IChessMoveTypeSpecification
    {
        protected abstract IEnumerable<PositionChange> AllowedMoves { get; }
        
        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return AllowedMoves.SelectMany(move => MoveWhileValid(currentPosition, move));
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