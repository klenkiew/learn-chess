using System.Collections.Generic;
using System.Linq;

namespace LearnChess.Application.Domain
{
    internal class ChessPiece
    {
        private readonly ICollection<IChessMoveTypeSpecification> pieceAllowedMoveTypes;

        public ChessPiece(ICollection<IChessMoveTypeSpecification> pieceAllowedMoveTypes)
        {
            this.pieceAllowedMoveTypes = pieceAllowedMoveTypes;
        }

        public IEnumerable<ChessMove> GetPossibleMoves(ChessboardPosition currentPosition)
        {
            return pieceAllowedMoveTypes.SelectMany(moveType => moveType.GetPossibleMoves(currentPosition)).Distinct();
        }
    }
}